using AutoMapper;
using Castle.Core.Logging;
using FluentValidation;
using FluentValidation.Results;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Controllers;
using NotificationService.Dtos;
using NotificationService.Mapper;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NotificationService.Tests.Controllers
{
    [TestSubject(typeof(AdminController))]
    public class AdminControllerTest
    {

        private AdminController adminController;
        private readonly Mock<INotificationTemplateService> _template;
        private readonly Mock<ILogger<AdminController>> _logger;
        private readonly Mock<IValidator<AddTemplateRequest>> _validatorMock;
        private readonly IMapper _mapper;


        public AdminControllerTest()
        {

            _validatorMock = new Mock<IValidator<AddTemplateRequest>>();

            var mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<TemplateProfiles>();
                },
                loggerFactory: new NullLoggerFactory()
                );

            _mapper = mapper.CreateMapper();

            _template = new Mock<INotificationTemplateService>();


        }

        [Fact]
        public async Task Post_WithValidRequest_ReturnsOkResult()
        {
            var template = new AddTemplateRequest(
                Name: "Начальный шаблон",
                Description: "Описание начльного шаблона",
                Type: "Authoriztion",
                Subject: "Добро пожаловать!",
                Template: @"<html>
                    <body>
                        <h1>Добро пожаловать, {{UserName}} !</h1>
                        <p>Ваш email: {{Email}}</p>
                        <p>Дата регистрации: {{RegistrationDate}}</p>
                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>
                    </body>
                </html>");
            var validationResult = new ValidationResult();

            _validatorMock.Setup(v => v.ValidateAsync(template, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(validationResult);

            adminController = new AdminController(_template.Object, new NullLogger<AdminController>(), _mapper, _validatorMock.Object);
            var res = await adminController.Post(template);

            Assert.IsType<OkResult>(res);
        }
    }
}