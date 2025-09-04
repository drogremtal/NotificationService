using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Notification.Infrastructure.Email.Dtos;
using Notification.Infrastructure.Email.Interface;
using NotificationService.Infrastructure.Interface;
using NotificationService.Infrastructure.Messaging.Config;
using System.Text.Json;
using static Confluent.Kafka.ConfigPropertyNames;

namespace NotificationService.Infrastructure.Messaging
{
    public class KafkaMessageConsumer:BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly ISmtpEmailService _smtpEmailService;
        private readonly string _topic;

        private readonly ILogger<KafkaMessageConsumer> _logger;

        //private readonly INotificationProcessor _notificationProcessor;

        public KafkaMessageConsumer(IConsumer<string, string> consumer, ISmtpEmailService smtpEmailService
            , ILogger<KafkaMessageConsumer> logger
            //,INotificationProcessor notificationProcessor
            )
        {
            _smtpEmailService = smtpEmailService;
            _consumer = consumer;
            _topic = "notifications_send";
            _logger = logger;  
            //_notificationProcessor = notificationProcessor;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting Kafka notification worker...");

            _consumer.Subscribe(_topic);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(stoppingToken);

                        _logger.LogInformation("Received message from Kafka: {Message}",consumeResult.Message.Value);

         
                        var message = consumeResult.Message.Value;
                        _logger.LogInformation("Processing notification: {Message}", message);

                        EmailNotification emailNotification = JsonSerializer.Deserialize<EmailNotification>(message);

                        await _smtpEmailService.SendMessage(emailNotification);

                        _logger.LogInformation("Notification processed successfully");


                        // Подтверждение обработки
                        _consumer.Commit(consumeResult);
                    }
                    catch (ConsumeException ex)
                    {
                        _logger.LogError(ex, "Error consuming message from Kafka");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error processing Kafka message");
                    }
                }
            }
            finally
            {
                _consumer.Close();
            }
        }
    }
}
