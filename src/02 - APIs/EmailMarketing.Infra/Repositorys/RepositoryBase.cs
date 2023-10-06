using EmailMarketing.Domain.Interfaces;
using EmailMarketing.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EmailMarketing.Infra.Repositorys
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly EmailMarketingContext _context;

        protected RepositoryBase(EmailMarketingContext context)
        {
            _context = context;
        }

        public async Task<T> ById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> List()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async void Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
