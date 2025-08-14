using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null,
       int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
        Task<TEntity> GetByIdAsync(int? id, Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> Table { get; }
    }
}
