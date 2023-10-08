namespace EmailMarketing.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IEmpresaRepository Empresas { get; }
        IPermissoesRepository Permissoes { get; }
        IUsuarioRepository Usuarios { get; }
        IMensagemRepository Mensagens { get; }
        ICampanhaRepository Campanhas { get; }
        Task<bool> CommitAsync();
    }
}
