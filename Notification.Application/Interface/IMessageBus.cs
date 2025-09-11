using NotificationService.Application.Dtos;

namespace NotificationService.Application.Interface
{
    public interface IMessageBus
    {
        Task PushNotification(NotificationSendRequest notification);
    }
}
