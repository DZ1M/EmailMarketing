using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class MensagemRepository : RepositoryBase<Mensagem>, IMensagemRepository
    {
        public MensagemRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
