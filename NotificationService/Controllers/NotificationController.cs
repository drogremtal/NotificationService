using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Core.Interfaces;
using NotificationService.Domain.Model;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : Controller
    {

        private readonly INotificationSender _notificationSender;


        public NotificationController(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }




        /// <summary>
        /// Отправка сообющений
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        [HttpPost(Name = "SendNotification")]
        public async Task<IActionResult> SendNotificationAsync(Notification notification)
        {
            try
            {
               await _notificationSender.SendAsync(notification);
            }
            catch (Exception ex) { }

            return Ok();

        }
    }
}
