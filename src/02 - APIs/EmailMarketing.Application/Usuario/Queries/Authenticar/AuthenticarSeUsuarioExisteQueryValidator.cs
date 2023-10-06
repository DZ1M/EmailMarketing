using FluentValidation;

namespace EmailMarketing.Application.Usuario.Queries.Authenticar
{
    public class AuthenticarSeUsuarioExisteQueryValidator : AbstractValidator<AuthenticarSeUsuarioExisteQuery>
    {
        public AuthenticarSeUsuarioExisteQueryValidator()
        {
            RuleFor(c => c.Senha)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(c => c.Senha)
                    .MinimumLength(6);
                });

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
