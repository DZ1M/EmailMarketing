using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class ContatoRepository : RepositoryBase<Contato>, IContatoRepository
    {
        public ContatoRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
