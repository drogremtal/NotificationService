using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification(SendNotificationRequest notification)
        {

            var sendNotificationDto = new SendNotificationDto()
            {
                Message = notification.Message,
                Title = notification.Title,
                Recipient = notification.Recipient
            };
            await _notificationService.SendNotificationAsync(sendNotificationDto);
            return Ok();
        }
    }
}
