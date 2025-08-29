using Core;
using System.Linq.Expressions;


namespace Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entity);
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IQueryable<TEntity>> GetAllsAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null);
        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null,
       int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? filter = null, int? id=0);
        IQueryable<TEntity> Table { get; }
    }
}
