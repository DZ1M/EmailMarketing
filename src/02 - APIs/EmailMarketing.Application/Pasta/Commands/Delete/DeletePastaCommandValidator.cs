using FluentValidation;

namespace EmailMarketing.Application.Pasta.Commands.Delete
{
    public class DeletePastaCommandValidator : AbstractValidator<DeletePastaCommand>
    {
        public DeletePastaCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
