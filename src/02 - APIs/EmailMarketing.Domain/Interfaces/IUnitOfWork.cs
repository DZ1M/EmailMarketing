namespace EmailMarketing.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IEmpresaRepository Empresa { get; }
        IPermissoesRepository Permissoes { get; }
        IUsuarioRepository Usuario { get; }
        Task<bool> CommitAsync();
    }
}
