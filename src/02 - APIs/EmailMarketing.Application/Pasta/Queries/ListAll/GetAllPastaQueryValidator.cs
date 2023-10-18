using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMarketing.Application.Pasta.Queries.ListAll
{
    public class GetAllPastaQueryValidator : AbstractValidator<GetAllPastaQuery>
    {
        public GetAllPastaQueryValidator() { }
    }
}
