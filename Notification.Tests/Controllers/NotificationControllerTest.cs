using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Moq;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Controllers;
using NotificationService.Dtos;
using System.Threading.Tasks;
using Xunit;

namespace Notification.Tests.Controllers
{
    [TestSubject(typeof(NotificationController))]
    public class NotificationControllerTest
    {

        private readonly Mock<INotificationService> _mockNotificationService;
        private readonly NotificationController _notificationController;


        public NotificationControllerTest()
        {
            _mockNotificationService = new Mock<INotificationService>();
            _notificationController = new NotificationController(_mockNotificationService.Object);
        }


        [Fact]
        public async Task SendNotification_WithValidRequest_ReturnsOkResult()
        {
            //arrange
            var sendNotificationRequest = new SendNotificationRequest()
            {
                Message = "Message",
                Recipient = "test@mail.ru",
                Title = "title"
            };

            _mockNotificationService.Setup(q => q.SendNotificationAsync(It.IsAny<SendNotification>()))
                .Returns(Task.CompletedTask);

            //assert

            var res = await _notificationController.SendNotification(sendNotificationRequest);

            //act

            Assert.IsType<OkResult>(res);

        }
    }
}