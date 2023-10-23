using FluentValidation;

namespace EmailMarketing.SenderMail.Application.ControleEmail.Commands.Create
{
    public class CriarControleEmailCommandValidator : AbstractValidator<CriarControleEmailCommand>
    {
        public CriarControleEmailCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Smtp)
             .NotEmpty();

            RuleFor(c => c.Usuario)
             .NotEmpty();

            RuleFor(c => c.Senha)
             .NotEmpty();
        }
    }
}
