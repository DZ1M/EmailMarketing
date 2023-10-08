using EmailMarketing.SenderMail.Domain.Interfaces;
using EmailMarketing.SenderMail.Infra.Context;

namespace EmailMarketing.SenderMail.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmailMarketingContext _context;
        public IControleEmailRepository ControleEmails { get; }
        public UnitOfWork(EmailMarketingContext context,
            IControleEmailRepository controleEmails)
        {
            _context = context;
            ControleEmails = controleEmails;
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
