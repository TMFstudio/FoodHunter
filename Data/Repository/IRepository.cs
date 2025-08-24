using Core;
using System.Linq.Expressions;


namespace Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllsAsync(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null);
        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null,
       int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
        Task<TEntity> GetByIdAsync(int? id, Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> Table { get; }
    }
}
