namespace EmailMarketing.SenderMail.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> ById(Guid id);
        Task<IEnumerable<TEntity>> List();
        IQueryable<TEntity> Query();
    }
}
