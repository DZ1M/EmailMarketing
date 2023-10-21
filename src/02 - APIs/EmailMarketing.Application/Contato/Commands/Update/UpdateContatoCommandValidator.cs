using FluentValidation;

namespace EmailMarketing.Application.Contato.Commands.Update
{
    public class UpdateContatoCommandValidator : AbstractValidator<UpdateContatoCommand>
    {
        public UpdateContatoCommandValidator()
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
                        .MaximumLength(200);
                    });
            });

            When(x => x.Telefone is not null, () =>
            {
                RuleFor(c => c.Telefone)
                    .NotEmpty()
                    .DependentRules(() =>
                    {
                        RuleFor(c => c.Telefone)
                        .MaximumLength(25);
                    });
            });

            When(x => x.Email is not null, () =>
            {
                RuleFor(c => c.Email)
                    .NotEmpty()
                    .DependentRules(() =>
                    {
                        RuleFor(c => c.Email)
                        .EmailAddress()
                        .DependentRules(() =>
                        {
                            RuleFor(c => c.Email)
                            .MaximumLength(150);
                        });
                    });
            });
        }
    }
}
