using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmailMarketingContext _context;
        public IEmpresaRepository Empresa { get; }
        public IPermissoesRepository Permissoes { get; }
        public IUsuarioRepository Usuario { get; }
        public UnitOfWork(EmailMarketingContext context,
            IEmpresaRepository empresa,
            IPermissoesRepository permissoes,
            IUsuarioRepository usuario)
        {
            _context = context;
            Empresa = empresa;
            Permissoes = permissoes;
            Usuario = usuario;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
