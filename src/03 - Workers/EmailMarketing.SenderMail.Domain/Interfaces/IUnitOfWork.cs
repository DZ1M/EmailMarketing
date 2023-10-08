namespace EmailMarketing.SenderMail.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IControleEmailRepository ControleEmails { get; }
        Task<bool> CommitAsync();
    }
}
