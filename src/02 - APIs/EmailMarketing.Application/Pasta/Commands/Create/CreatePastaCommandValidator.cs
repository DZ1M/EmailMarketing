using FluentValidation;

namespace EmailMarketing.Application.Pasta.Commands.Create
{
    public class CreatePastaCommandValidator : AbstractValidator<CreatePastaCommand>
    {
        public CreatePastaCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(c => c.Nome)
                    .MinimumLength(2)
                    .MaximumLength(150);
                });
        }
    }
}
