using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Controllers;
using NotificationService.Dtos;
using System.Threading.Tasks;
using Xunit;

namespace NotificationService.Tests.Controllers
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
            var sendNotificationRequest =
                new SendNotificationRequest(Recipient: "test@mail.ru", Subject: "title", Message: "Message");

            _mockNotificationService.Setup(q => q.SendNotificationAsync(It.IsAny<SendNotification>()))
                .Returns(Task.CompletedTask);

            //assert

            var res = await _notificationController.SendNotification(sendNotificationRequest);

            //act

            Assert.IsType<OkResult>(res);

        }
    }
}