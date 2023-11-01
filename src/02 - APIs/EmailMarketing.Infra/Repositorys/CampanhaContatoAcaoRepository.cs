using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class CampanhaContatoAcaoRepository : RepositoryBase<CampanhaContatoAcao>, ICampanhaContatoAcaoRepository
    {
        public CampanhaContatoAcaoRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
