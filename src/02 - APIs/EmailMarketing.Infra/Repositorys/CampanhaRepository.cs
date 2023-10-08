using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class CampanhaRepository : RepositoryBase<Campanha>, ICampanhaRepository
    {
        public CampanhaRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
