using FluentValidation;

namespace EmailMarketing.Application.Pasta.Queries.ById
{
    public class GetPastaByIdQueryValidator : AbstractValidator<GetPastaByIdQuery>
    {
        public GetPastaByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
