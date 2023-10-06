using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
