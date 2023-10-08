using EmailMarketing.SenderMail.Domain.Interfaces;
using EmailMarketing.SenderMail.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.SenderMail.Infra.Repositorys
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly EmailMarketingContext _context;

        protected RepositoryBase(EmailMarketingContext context)
        {
            _context = context;
        }

        public async Task<TEntity> ById(Guid id)
            => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> List()
            => await _context.Set<TEntity>().ToListAsync();

        public async void Create(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);

        public IQueryable<TEntity> Query()
            => _context.Set<TEntity>().AsQueryable();
    }
}
