using FluentValidation;

namespace EmailMarketing.Application.Modelo.Commands.Update
{
    public class UpdateModeloCommandValidator : AbstractValidator<UpdateModeloCommand>
    {
        public UpdateModeloCommandValidator()
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

            When(x => x.Texto is not null, () =>
            {
                RuleFor(c => c.Texto)
                    .NotEmpty();
            });
        }
    }
}
