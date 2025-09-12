using FluentValidation;
using NotificationService.Dtos.Template;

namespace NotificationService.Dtos.Validators
{
    public class AddTemplateValidator : AbstractValidator<AddTemplateRequest>
    {
        public AddTemplateValidator()
        {
            RuleFor(q => q.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(q => q.Template)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(300);

            RuleFor(q => q.Type)
                .NotEmpty();

            RuleFor(q => q.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(10)
                .MaximumLength(300);
        }
    }
}
