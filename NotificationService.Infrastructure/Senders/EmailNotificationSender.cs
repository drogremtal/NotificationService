using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NotificationService.Core.Interfaces;
using NotificationService.Domain.Model;
using NotificationService.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Senders
{
    public class EmailNotificationSender : INotificationSender
    {

        private readonly SmtpClient _smtpClient;
        private readonly SmtpConfig _SmtpConfig;

        public EmailNotificationSender(IOptions<SmtpConfig> configuration)
        {

            _SmtpConfig = configuration.Value;
            _smtpClient = new SmtpClient()
            {

                Host = _SmtpConfig.ServerAddress,
                Port = _SmtpConfig.Port,
                EnableSsl = _SmtpConfig.EnableSsl,
                Credentials = new System.Net.NetworkCredential(_SmtpConfig.UserName, _SmtpConfig.Password)

            };
        }
        public async Task SendAsync(Notification notification)
        {
            var message = new MailMessage(from: _SmtpConfig.From, to: notification.Recipient)
            {
                Body = notification.Body,
                Subject = notification.Subject,
            };

            await _smtpClient.SendMailAsync(message);

        }
    }
}
