using Microsoft.Extensions.Logging;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using System.Text.Json;



namespace NotificationService.Infrastructure.Messaging
{
    public class NotificationProcessor : INotificationProcessor
    {

        private readonly ILogger<NotificationProcessor> _logger;
        private readonly ISmtpEmailService _smtpEmailService;
        private readonly INotificationTemplateService _notificationTemplateSevice; 
        public NotificationProcessor(ILogger<NotificationProcessor> logger, ISmtpEmailService smtpEmailService, INotificationTemplateService _notificationTemplateSevice)
        {
            _logger = logger;
            _smtpEmailService = smtpEmailService;
        }
        public async Task ProcessNotificationAsync(string notification, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Processing notification: {Message}", notification);

                var notificationSendRequest = JsonSerializer.Deserialize<NotificationSendRequest>(notification);

                if (notificationSendRequest != null)
                {
                    var email = await this.PrepareEmailAsync(notificationSendRequest);
                    await _smtpEmailService.SendMessage(email);
                }

                _logger.LogInformation("Notification processed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing notification");
                throw;
            }
        }

        public async Task<EmailNotification> PrepareEmailAsync(NotificationSendRequest notificationSendRequest)
        {
            var template = await _notificationTemplateSevice.GetTemplateByType(notificationSendRequest.Type);

            if (template == null)
                throw new ArgumentException($"Template '{notificationSendRequest.Type}' not found");

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
                IsHtml = notificationSendRequest.IsHtml  ,
                Recipient = notificationSendRequest.Recipient,
            };
        }
    }
}
