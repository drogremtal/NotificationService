using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationService.Application.Interface;


namespace NotificationService.Infrastructure.Messaging
{
    public class KafkaMessageConsumer:BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly ISmtpEmailService _smtpEmailService;
        private readonly string _topic;

        private readonly ILogger<KafkaMessageConsumer> _logger;

        private readonly INotificationProcessor _notificationProcessor;

        public KafkaMessageConsumer(IConsumer<string, string> consumer, ISmtpEmailService smtpEmailService
            , ILogger<KafkaMessageConsumer> logger
            ,INotificationProcessor notificationProcessor
            )
        {
            _smtpEmailService = smtpEmailService;
            _consumer = consumer;
            _topic = "notifications_send";
            _logger = logger;  
            _notificationProcessor = notificationProcessor;

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

                        if (consumeResult != null)
                        {
                            _logger.LogInformation("Received message from Kafka: {Message}", consumeResult.Message.Value);

                            var message = consumeResult.Message.Value;
                            
                            _logger.LogInformation("Processing notification: {Message}", message);

           
                            if (message != null)
                            {
                                await _notificationProcessor.ProcessNotificationAsync(message, stoppingToken);
                            }
                            _logger.LogInformation("Notification processed successfully");
                            // Подтверждение обработки
                            _consumer.Commit(consumeResult);
                        }
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
