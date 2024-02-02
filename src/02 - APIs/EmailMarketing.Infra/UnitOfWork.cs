using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;

namespace EmailMarketing.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmailMarketingContext _context;
        public IEmpresaRepository Empresas { get; }
        public IPermissoesRepository Permissoes { get; }
        public IUsuarioRepository Usuarios { get; }
        public ICampanhaRepository Campanhas { get; }
        public IContatoRepository Contatos { get; }
        public ICampanhaContatoRepository CampanhaContatos { get; }
        public ICampanhaContatoAcaoRepository CampanhaContatosAcoes { get; }
        public IModeloRepository Modelos { get; }
        public IPastaRepository Pastas { get; }
        public UnitOfWork(EmailMarketingContext context,
            IEmpresaRepository empresa,
            IPermissoesRepository permissoes,
            IUsuarioRepository usuario,
            ICampanhaRepository campanhas,
            IContatoRepository contatos,
            ICampanhaContatoRepository campanhasContatos,
            IModeloRepository modelos,
            IPastaRepository pastas,
            ICampanhaContatoAcaoRepository campanhaContatosAcoes)
        {
            _context = context;
            Empresas = empresa;
            Permissoes = permissoes;
            Usuarios = usuario;
            Campanhas = campanhas;
            Contatos = contatos;
            CampanhaContatos = campanhasContatos;
            Modelos = modelos;
            Pastas = pastas;
            CampanhaContatosAcoes = campanhaContatosAcoes;
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
