using FluentValidation;

namespace NotificationService.Dtos.Validators
{
    public class EditTemplateValidator:AbstractValidator<EditTemplateDto>
    {
        public EditTemplateValidator()
        {
            RuleFor(q=>q.Id).NotEmpty();
            RuleFor(q => q.Name).NotEmpty();
            RuleFor(q => q.Template).NotEmpty();
            RuleFor(q => q.Description).NotEmpty();
            RuleFor(q => q.Type).NotEmpty();
        }
    }
}
