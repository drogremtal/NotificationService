using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NotificationService.Application.Dtos;
using NotificationService.Application.Interface;
using NotificationService.Controllers;
using NotificationService.Dtos.Template;
using NotificationService.Mapper;
using System;
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

        #region HttpPost AdminController/Add

        [Fact]
        public async Task Post_WithValidRequest_ReturnsOkResult()
        {
            var template = new AddTemplateRequest(
                Name: "Начальный шаблон",
                Description: "Описание начльного шаблона",
                Type: "Authorization",
                Subject: "Добро пожаловать!",
                Template: @"<html>
                    <body>
                        <h1>Добро пожаловать, {{UserName}} !</h1>
                        <p>Ваш email: {{Email}}</p>
                        <p>Дата регистрации: {{RegistrationDate}}</p>
                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>
                    </body>
                </html>",
                Enabled:true);
            var validationResult = new ValidationResult();

            _validatorMock.Setup(v => v.ValidateAsync(template, It.IsAny<CancellationToken>()))
                         .ReturnsAsync(validationResult);

            adminController = new AdminController(_template.Object, new NullLogger<AdminController>(), _mapper, _validatorMock.Object);
            var res = await adminController.Add(template);

            Assert.IsType<OkResult>(res);
        }



        #endregion HttpPost AdminController/Add



        #region GetById


        [Fact]
        public async Task Get_ShouldId_ReturnData()
        {
            var id = Guid.NewGuid();

            var template = new TemplateDto
            {
                Id = id,
                Name = "Начальный шаблон",
                Description = "Описание начльного шаблона",
                Type = "Authorization",
                Subject = "Добро пожаловать!",
                Enabled = true,
                CreatedDate = DateTime.Parse("01.01.2025"),
                UpdatedDate = null,
                AuthtorCreated = "Test",
                AuthtorUpdated = String.Empty,
                Template = @"<html>
                    <body>
                        <h1>Добро пожаловать, {{UserName}} !</h1>
                        <p>Ваш email: {{Email}}</p>
                        <p>Дата регистрации: {{RegistrationDate}}</p>
                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>
                    </body>
                </html>"
            };

            adminController = new AdminController(_template.Object, new NullLogger<AdminController>(), _mapper, _validatorMock.Object);


            _template.Setup(q => q.Get(It.IsAny<Guid>())).ReturnsAsync(template);
            var res = await adminController.Get(id);
            Assert.IsType<ActionResult<TemplateResponse>>(res);
        }


        [Fact]
        public async Task Get_ShouldId_ReturnNull()
        {
            var id = Guid.NewGuid();

            adminController = new AdminController(_template.Object, new NullLogger<AdminController>(), _mapper, _validatorMock.Object);

            _template.Setup(q => q.Get(It.IsAny<Guid>())).ReturnsAsync((TemplateDto)null);
            var res = await adminController.Get(id);
            Assert.IsType<ActionResult<TemplateResponse>>(res);
            Assert.Null(res.Value);
        }


        [Fact]
        public async Task Get_ShouldId_ReturnException()
        {
            var id = Guid.NewGuid();

            adminController = new AdminController(_template.Object, new NullLogger<AdminController>(), _mapper, _validatorMock.Object);

            _template.Setup(q => q.Get(It.IsAny<Guid>())).ThrowsAsync(new Exception("Ошибка"));
            var res = await adminController.Get(id);

            Assert.IsType<BadRequest>(res);


        }
        #endregion
    }
}