using FluentValidation;

namespace EmailMarketing.Application.Admin.Auth.Register
{
    public class RegistrarUsuarioCommandValidator : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioCommandValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty();

            RuleFor(c => c.NomeEmpresa)
                .NotEmpty();

            RuleFor(c => c.Senha)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(c => c.Senha)
                    .MinimumLength(6);

                    RuleFor(c => c.SenhaConfirmacao)
                        .NotEmpty();

                    RuleFor(usuario => usuario.SenhaConfirmacao)
                        .Must((usuario, confirmarSenha) => confirmarSenha == usuario.Senha)
                        .WithMessage("As senhas não coincidem.");
                });

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

        }
    }
}
