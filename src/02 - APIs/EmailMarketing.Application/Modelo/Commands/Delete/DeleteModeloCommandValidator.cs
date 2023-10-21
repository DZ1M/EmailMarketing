using FluentValidation;

namespace EmailMarketing.Application.Modelo.Commands.Delete
{
    public class DeleteModeloCommandValidator : AbstractValidator<DeleteModeloCommand>
    {
        public DeleteModeloCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
