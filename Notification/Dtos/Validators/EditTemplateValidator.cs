using FluentValidation;
using NotificationService.Dtos.Template;

namespace NotificationService.Dtos.Validators
{
    public class EditTemplateValidator:AbstractValidator<EditTemplateRequest>
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
