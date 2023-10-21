namespace EmailMarketing.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IEmpresaRepository Empresas { get; }
        IPermissoesRepository Permissoes { get; }
        IUsuarioRepository Usuarios { get; }
        ICampanhaRepository Campanhas { get; }
        IContatoRepository Contatos { get; }
        ICampanhaContatoRepository CampanhaContatos { get; }
        IModeloRepository Modelos { get; }
        IPastaRepository Pastas { get; }
        Task<bool> CommitAsync();
    }
}
