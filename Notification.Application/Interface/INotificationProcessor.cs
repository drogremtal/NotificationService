using Notification.Infrastructure.Email.Dtos;
using NotificationService.Infrastructure.Email.Dtos;

namespace NotificationService.Application.Interface
{
    public interface INotificationProcessor
    {
        Task ProcessNotificationAsync(string message,CancellationToken token);


        Task<EmailNotification> PrepareEmailAsync(NotificationSendRequest emailNotification);
    }
}
