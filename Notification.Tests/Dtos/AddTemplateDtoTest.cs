using FluentValidation.TestHelper;
using JetBrains.Annotations;
using NotificationService.Dtos.Template;
using NotificationService.Dtos.Validators;
using Xunit;


namespace NotificationService.Tests.Dtos
{
    [TestSubject(typeof(AddTemplateRequest))]
    public class AddTemplateDtoTest
    {
        private readonly AddTemplateValidator _validator;

        public AddTemplateDtoTest()
        {
            _validator = new AddTemplateValidator();
        }

        [Fact]
        public void AddTemplateDto_Valid_AllProperetyValid()
        {
            var template = new AddTemplateRequest(
                Name: "Шаблон",
                Description: "Описание шаблона",
                Type: "Тип шаблона",
                Subject: "",
                Template: "Шаблон сообщения",
                Enabled: true);


            var res = _validator.TestValidate(template);

            res.ShouldNotHaveAnyValidationErrors();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Name_NotBeEmpty([CanBeNull] string Name)
        {

            var template = new AddTemplateRequest(
                Name: Name,
                Description: "Описание шаблона",
                Type: "Тип шаблона",
                Subject: "",
                Template: "Шаблон сообщения"
                , Enabled: true
                );

            var res = _validator.TestValidate(template);
            res.ShouldHaveValidationErrorFor(q => q.Name);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Description_NotBeEmpty([CanBeNull] string Description)
        {

            var template = new AddTemplateRequest(
                Name: "Шаблон",
                Description: Description,
                Type: "Тип шаблона",
                Subject: "",
                Template: "Шаблон сообщения"
                , Enabled: true);

            var res = _validator.TestValidate(template);
            res.ShouldHaveValidationErrorFor(q => q.Description);

        }

    }
}