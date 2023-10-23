using FluentValidation;

namespace EmailMarketing.Application.Contato.Queries.ById
{
    public class GetContatoByIdQueryValidator : AbstractValidator<GetContatoByIdQuery>
    {
        public GetContatoByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
