using NotificationService.Domain.Entities;
using Notification.Infrastructure.Email.Dtos;
using Notification.Infrastructure.Email.Interface;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Domain.Interface;

namespace NotificationService.Application.Services
{
    public class NotificationAppService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ISmtpEmailService _smtpEmailService;

        public NotificationAppService(INotificationRepository notificationRepository, ISmtpEmailService smtpEmailService)
        {
            _notificationRepository = notificationRepository;
            _smtpEmailService = smtpEmailService;
        }


        public async Task SendNotificationAsync(SendNotificationDto sendNotificationDto)
        {
            var notification = new NotificationEntity()
            {
                Recipient = sendNotificationDto.Recipient,
                Title = sendNotificationDto.Title,
                Message = sendNotificationDto.Message,
                CreatedAt = DateTime.Now,
            };

            await _notificationRepository.AddAsync(notification);


            var emailNotification = new EmailNotification()
            {
                Recipient = sendNotificationDto.Recipient,
                IsHtml = true,
                Subject = sendNotificationDto.Title,
                Message = sendNotificationDto.Message,
            };

            var res = await _smtpEmailService.SendMessage(emailNotification);

        }


    }
}
