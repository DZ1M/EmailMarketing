using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class MensagemContatoRepository : RepositoryBase<MensagemContato>, IMensagemContatoRepository
    {
        public MensagemContatoRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
