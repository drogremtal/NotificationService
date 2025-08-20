using NotificationService.Application.Dtos;

namespace NotificationService.Application.Interface
{
    public interface INotificationService
    {
        Task SendNotificationAsync(SendNotificationDto sendNotificationDto);
    }
}
