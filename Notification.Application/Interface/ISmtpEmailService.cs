using NotificationService.Application.Dtos;

namespace NotificationService.Application.Interface
{
    public interface ISmtpEmailService
    {
        Task<bool> SendMessage(EmailNotification emailNotification);
    }

}
