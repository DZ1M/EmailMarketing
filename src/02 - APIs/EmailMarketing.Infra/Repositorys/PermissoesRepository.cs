using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class PermissoesRepository : RepositoryBase<Permissao>, IPermissoesRepository
    {
        public PermissoesRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
