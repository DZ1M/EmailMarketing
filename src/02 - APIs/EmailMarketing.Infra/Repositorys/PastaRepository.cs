using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class PastaRepository : RepositoryBase<Pasta>, IPastaRepository
    {
        public PastaRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
