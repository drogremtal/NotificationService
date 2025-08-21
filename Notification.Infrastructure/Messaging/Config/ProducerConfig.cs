using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Messaging.Config
{
    public record KafkaProducerConfig
    {
        public required string BootstrapServers { get; init; }
        public required string Topic { get; init; }

    }
}
