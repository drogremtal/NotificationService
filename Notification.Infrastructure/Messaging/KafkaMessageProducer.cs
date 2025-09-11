using Confluent.Kafka;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Infrastructure.Messaging.Config;
using System.Text.Json;


namespace NotificationService.Infrastructure.Messaging
{
    public class KafkaMessageProducer : IMessageBus
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;
        private readonly KafkaProducerConfig _kafkaProducerConfig;

        public KafkaMessageProducer(IProducer<string, string> services)
        {
            _producer = services;

            //_kafkaProducerConfig = kafkaProducerConfig.Value;

            //var producerConfig = new ProducerConfig()
            //{
            //    BootstrapServers = _kafkaProducerConfig.BootstrapServers,
            //};

            //_producer = new ProducerBuilder<Null, string>(producerConfig).Build();
            _topic = "notifications_send";

        }

        public async Task PushNotification(NotificationSendRequest notification)
        {
            var jsonMessage = JsonSerializer.Serialize(notification);

            await _producer.ProduceAsync(_topic, new Message<string, string> { Value = jsonMessage });
        }
    }
}
