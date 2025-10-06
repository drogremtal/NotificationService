using Microsoft.Extensions.Logging;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using System.Text.Json;



namespace NotificationService.Infrastructure.Messaging
{
    public class NotificationProcessor(
        ILogger<NotificationProcessor> logger,
        ISmtpEmailService smtpEmailService,
        INotificationTemplateService notificationTemplateService)
        : INotificationProcessor
    {
        public async Task ProcessNotificationAsync(string notification, CancellationToken cancellationToken)
        {
            try
            {
                logger.LogInformation("Processing notification: {Message}", notification);

                var notificationSendRequest = JsonSerializer.Deserialize<NotificationSendRequest>(notification);

                if (notificationSendRequest != null)
                {
                    var email = await this.PrepareEmailAsync(notificationSendRequest);
                    await smtpEmailService.SendMessage(email);
                }

                logger.LogInformation("Notification processed successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing notification");
                throw;
            }
        }

        public async Task<EmailNotification> PrepareEmailAsync(NotificationSendRequest notificationSendRequest)
        {
            var template = await notificationTemplateService.GetTemplateByType(notificationSendRequest.Type);

            if (template == null)
                throw new ArgumentException($"Template '{notificationSendRequest.Type}' not found");

            if (!template.Enabled)
            {
                throw new Exception("The template is disabled");
            }

            string subject = template.Subject;
            string body = template.Template;

            foreach (var param in notificationSendRequest.Parameters)
            {
                subject = subject.Replace($"{{{{{param.Key}}}}}", param.Value);
                body = body.Replace($"{{{{{param.Key}}}}}", param.Value);
            }

            return new EmailNotification
            {

                Subject = subject,
                Body = body,
                IsHtml = notificationSendRequest.IsHtml,
                Recipient = notificationSendRequest.Recipient,
            };
        }
    }
}
