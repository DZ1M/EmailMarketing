using FluentValidation;

namespace EmailMarketing.Application.Usuario.Queries.BuscarPorEmail
{
    public class GetUsuarioByEmailQueryValidator : AbstractValidator<GetUsuarioByEmailQuery>
    {
        public GetUsuarioByEmailQueryValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

        }
    }
}
