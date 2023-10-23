using FluentValidation;

namespace EmailMarketing.Application.Campanha.Commands.Create
{
    public class CreateCampanhaCommandValidator : AbstractValidator<CreateCampanhaCommand>
    {
        public CreateCampanhaCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(c => c.Nome)
                    .MinimumLength(2)
                    .MaximumLength(250);
                });
            
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(c => c.Titulo)
                    .MinimumLength(2)
                    .MaximumLength(250);
                });
        }
    }
}
