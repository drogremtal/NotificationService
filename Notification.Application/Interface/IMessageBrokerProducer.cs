using NotificationService.Application.Dtos;

namespace NotificationService.Application.Interface
{
    public interface IMessageBrokerProducer
    {
        Task PushNotification(NotificationSendRequest notification);
    }
}
