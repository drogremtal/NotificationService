using NotificationService.Application.Dtos;

namespace NotificationService.Application.Interface
{
    public interface INotificationService
    {
        Task SendNotificationAsync(SendNotification sendNotificationDto);
        Task SendNotificationMqAsync(SendNotificationMQ sendNotificationDto);
    }
}
