using Microsoft.Extensions.Options;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Infrastructure.Email.Dtos;
using System.Net;
using System.Net.Mail;

namespace NotificationService.Infrastructure.Email
{

    public class SmtpEmailService : ISmtpEmailService
    {

        private readonly SmtpConfig _smtpConfig;
        private readonly SmtpClient _smtpClient;

        public SmtpEmailService(IOptions<SmtpConfig> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;

            _smtpClient = new SmtpClient(_smtpConfig.ServerAddress, _smtpConfig.Port)
            {
                EnableSsl = _smtpConfig.EnableSsl,
                Credentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password)
            };
        }


        public async Task<bool> SendMessage(EmailNotification emailNotification)
        {
            var mailMessage = CreateMailMessage(emailNotification);
            await _smtpClient.SendMailAsync(mailMessage);
            return true;
        }


        private MailMessage CreateMailMessage(EmailNotification emailNotification)
        {

            var message = new MailMessage
            {
                From = new MailAddress(_smtpConfig.From),
                Subject = emailNotification.Subject,
                Body = emailNotification.Body,
                IsBodyHtml = emailNotification.IsHtml
            };

            message.To.Add(emailNotification.Recipient);

            if (!string.IsNullOrEmpty(emailNotification.ReplyTo))
            {
                message.ReplyToList.Add(emailNotification.ReplyTo);
            }

            return message;
        }


    }
}
