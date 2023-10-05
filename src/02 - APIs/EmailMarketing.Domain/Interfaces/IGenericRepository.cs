namespace EmailMarketing.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> ById(Guid id);
        Task<IEnumerable<T>> List();
        IQueryable<T> Query();
    }
}
