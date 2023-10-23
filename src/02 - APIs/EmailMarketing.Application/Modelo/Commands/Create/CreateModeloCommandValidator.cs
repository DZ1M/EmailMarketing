using FluentValidation;

namespace EmailMarketing.Application.Modelo.Commands.Create
{
    public class CreateModeloCommandValidator : AbstractValidator<CreateModeloCommand>
    {
        public CreateModeloCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(c => c.Nome)
                    .MinimumLength(2)
                    .MaximumLength(255);
                });
        }
    }
}
