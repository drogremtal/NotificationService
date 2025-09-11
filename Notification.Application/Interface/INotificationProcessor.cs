using NotificationService.Application.Dtos;

namespace NotificationService.Application.Interface
{
    public interface INotificationProcessor
    {
        Task ProcessNotificationAsync(string message,CancellationToken token);

        Task<EmailNotification> PrepareEmailAsync(NotificationSendRequest emailNotification);
    }
}
