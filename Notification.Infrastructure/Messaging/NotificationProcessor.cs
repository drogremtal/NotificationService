using Microsoft.Extensions.Logging;
using Notification.Infrastructure.Email.Dtos;
using Notification.Infrastructure.Email.Interface;
using NotificationService.Infrastructure.Interface;
using System.Text.Json;

namespace NotificationService.Infrastructure.Messaging
{
    public class NotificationProcessor : INotificationProcessor
    {

        private readonly ILogger<NotificationProcessor> _logger;
        private readonly ISmtpEmailService _smtpEmailService;
        public NotificationProcessor(ILogger<NotificationProcessor> logger, ISmtpEmailService smtpEmailService)
        {
            _logger = logger;
            _smtpEmailService = smtpEmailService;
        }
        public async Task ProcessNotificationAsync(string message, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Processing notification: {Message}", message);

                EmailNotification emailNotification = JsonSerializer.Deserialize<EmailNotification>(message);

                await _smtpEmailService.SendMessage(emailNotification);

                _logger.LogInformation("Notification processed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing notification");
                throw;
            }
        }
    }
}
