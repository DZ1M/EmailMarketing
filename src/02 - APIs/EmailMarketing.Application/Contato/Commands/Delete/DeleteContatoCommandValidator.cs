using FluentValidation;

namespace EmailMarketing.Application.Contato.Commands.Delete
{
    public class DeleteContatoCommandValidator : AbstractValidator<DeleteContatoCommand>
    {
        public DeleteContatoCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
