using FluentValidation;

namespace EmailMarketing.Application.Usuario.Queries.GerarJwt
{
    public class GerarTokenCommandValidator : AbstractValidator<GerarTokenCommand>
    {
        public GerarTokenCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

        }
    }
}
