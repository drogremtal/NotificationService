using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using System;
using System.Text.Json;


namespace NotificationService.Infrastructure.Messaging
{
    public class KafkaMessageConsumer : BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly string _topic;
        private readonly ILogger<KafkaMessageConsumer> _logger;


        private readonly IServiceProvider _serviceProvider;
        public KafkaMessageConsumer(IConsumer<string, string> consumer
            , ILogger<KafkaMessageConsumer> logger,
            IServiceProvider serviceProvider
        )
        {
            _consumer = consumer;
            _topic = "notifications_send";
            _logger = logger;
            _serviceProvider = serviceProvider;

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
                        // Используем асинхронное потребление вместо синхронного
                        var consumeResult = _consumer.Consume(stoppingToken);

                        if (consumeResult != null)
                        {
                            _logger.LogInformation("Received message from Kafka: {Message}",
                                consumeResult.Message.Value);

                            try
                            {
                                var message = consumeResult.Message.Value;
                                _logger.LogInformation("Processing notification: {Message}", message);

                                if (message != null)
                                {

                                    using (var scope = _serviceProvider.CreateAsyncScope())
                                    {
                                        var notificationRequiredService = scope.ServiceProvider.GetRequiredService<INotificationProcessor>();

                                        await notificationRequiredService.ProcessNotificationAsync(message, stoppingToken);

                                    }
                                    _logger.LogInformation("Notification processed successfully");

                                    // Подтверждение обработки
                                    _consumer.Commit(consumeResult);
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error processing message: {Message}",
                                    consumeResult.Message.Value);
                                // Не коммитим сообщение при ошибке обработки
                            }
                        }
                    }
                    catch (ConsumeException ex)
                    {
                        _logger.LogError(ex, "Error consuming message from Kafka");
                        // Краткая пауза при ошибках потребления
                        await Task.Delay(1000, stoppingToken);
                    }
                    catch (OperationCanceledException)
                    {
                        // Нормальное завершение при отмене
                        break;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unexpected error in Kafka consumer");
                        await Task.Delay(5000, stoppingToken);
                    }
                }
            }
            finally
            {
                _consumer.Close();
                _logger.LogInformation("Kafka notification worker stopped");
            }
        }

        //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //    {
        //        _logger.LogInformation("Starting Kafka notification worker...");

        //        _consumer.Subscribe(_topic);

        //        try
        //        {
        //            while (!stoppingToken.IsCancellationRequested)

        //            {
        //                try
        //                {
        //                    var consumeResult = _consumer.Consume(stoppingToken);

        //                    if (consumeResult != null)
        //                    {
        //                        _logger.LogInformation("Received message from Kafka: {Message}", consumeResult.Message.Value);

        //                        var message = consumeResult.Message.Value;

        //                        _logger.LogInformation("Processing notification: {Message}", message);


        //                        if (message != null)
        //                        {
        //                            await _notificationProcessor.ProcessNotificationAsync(message, stoppingToken);
        //                        }
        //                        _logger.LogInformation("Notification processed successfully");
        //                        // Подтверждение обработки
        //                        _consumer.Commit(consumeResult);
        //                    }
        //                }
        //                catch (ConsumeException ex)
        //                {
        //                    _logger.LogError(ex, "Error consuming message from Kafka");
        //                }
        //                catch (Exception ex)
        //                {
        //                    _logger.LogError(ex, "Error processing Kafka message");
        //                }
        //            }
        //        }
        //        finally
        //        {
        //            _consumer.Close();
        //        }
        //    //}
        //}
    }
}
