using NotificationService.Application.Dtos;

namespace NotificationService.Application.Interface
{
    public interface INotificationSender
    {
        Task SendToKafka(SendNotificationDto notification);
        Task SendToEmail(SendNotificationDto notification);
    }
}
