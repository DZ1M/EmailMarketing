using FluentValidation;

namespace EmailMarketing.Application.Modelo.Queries.ById
{
    public class GetModeloByIdQueryValidator : AbstractValidator<GetModeloByIdQuery>
    {
        public GetModeloByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
