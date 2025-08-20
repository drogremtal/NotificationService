using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Email
{
    public record SmtpConfig
    {
        public required string ServerAddress { get; init; }
        public required int Port { get; init; }
        public required string UserName { get; init; }
        public required string Password { get; init; }
        public required string From { get; init; }
        public required bool EnableSsl { get; init; }
    }
}
