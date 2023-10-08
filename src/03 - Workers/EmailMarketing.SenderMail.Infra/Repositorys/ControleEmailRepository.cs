using EmailMarketing.SenderMail.Domain.Entities;
using EmailMarketing.SenderMail.Domain.Interfaces;
using EmailMarketing.SenderMail.Infra.Context;

namespace EmailMarketing.SenderMail.Infra.Repositorys
{
    public class ControleEmailRepository : RepositoryBase<ControleEmail>, IControleEmailRepository
    {
        public ControleEmailRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
