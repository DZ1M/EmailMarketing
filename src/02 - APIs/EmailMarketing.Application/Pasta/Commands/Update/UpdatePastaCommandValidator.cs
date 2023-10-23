using FluentValidation;

namespace EmailMarketing.Application.Pasta.Commands.Update
{
    public class UpdatePastaCommandValidator : AbstractValidator<UpdatePastaCommand>
    {
        public UpdatePastaCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

            When(x => x.Nome is not null, () =>
            {
                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .DependentRules(() =>
                    {
                        RuleFor(c => c.Nome)
                        .MinimumLength(2)
                        .MaximumLength(150);
                    });
                });
        }
    }
}
