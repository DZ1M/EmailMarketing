using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;
using EmailMarketing.Infra.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.ApplicationTests.Context
{
    public class TestDbContext : EmailMarketingContext
    {
        public TestDbContext(DbContextOptions<EmailMarketingContext> options)
            : base(options)
        {
        }
    }

    public class TestUnitOfWork : IUnitOfWork
    {
        private readonly EmailMarketingContext _context;
        public TestUnitOfWork(EmailMarketingContext context)
        {
            _context = context;
            Empresas = new EmpresaRepository(context);
            Permissoes = new PermissoesRepository(context);
            Usuarios = new UsuarioRepository(context);
            Campanhas = new CampanhaRepository(context);
            Contatos = new ContatoRepository(context);
            CampanhaContatos = new CampanhaContatoRepository(context);
            Modelos = new ModeloRepository(context);
            Pastas = new PastaRepository(context);
        }

        public IEmpresaRepository Empresas { get; }

        public IPermissoesRepository Permissoes { get; }

        public IUsuarioRepository Usuarios { get; }

        public ICampanhaRepository Campanhas { get; }

        public IContatoRepository Contatos { get; }

        public ICampanhaContatoRepository CampanhaContatos { get; }

        public IModeloRepository Modelos { get; }

        public IPastaRepository Pastas { get; }

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
