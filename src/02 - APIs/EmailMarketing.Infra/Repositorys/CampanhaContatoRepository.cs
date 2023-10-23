using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class CampanhaContatoRepository : RepositoryBase<CampanhaContato>, ICampanhaContatoRepository
    {
        public CampanhaContatoRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
