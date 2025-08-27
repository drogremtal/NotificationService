using FluentValidation;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Moq;
using NotificationService.Application.Interface;
using NotificationService.Controllers;
using NotificationService.Dtos;
using Xunit;

namespace NotificationService.Tests.Controllers
{
    [TestSubject(typeof(AdminController))]
    public class AdminControllerTest
    {

        private AdminController adminController;
        private readonly Mock<INotificationTemplateService> _template;
        private readonly Mock<ILogger<AdminController> _logger;
        private readonly IValidator<AddTemplateDto> _validator;

        [Fact]
        public void METHOD()
        {
        }
    }
}