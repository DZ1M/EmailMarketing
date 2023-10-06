using EmailMarketing.Domain.Entities;
using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra.Repositorys
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EmailMarketingContext context) : base(context)
        {
        }
    }
}
