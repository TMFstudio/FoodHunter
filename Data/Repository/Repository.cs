using Core;
using Data.DataAccess;
using Data.Extantion;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _db;
        private DbSet<TEntity> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public virtual async Task InsertAsync(TEntity entity)
        {

                if (entity == null)
                    throw new ArgumentNullException("entity null exception");

               await this.Entities.AddAsync(entity);

               await _db.SaveChangesAsync();

        }
        public virtual async Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>> func = null,
       int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            var query = Table;

            query = func != null ? await func(query) : query;

            return await query.ToPagedListAsync(pageIndex, pageSize, getOnlyTotalCount);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = this.Entities;
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int? id,Expression<Func<TEntity,bool>>? filter = null)
        {
            if (!id.HasValue || id == 0)
                return null;

            IQueryable<TEntity> query = this.Entities;
            if (filter != null)
                query = query.Where(filter);

           return await query.FirstOrDefaultAsync(x=>x.Id==id);
        }


        public virtual async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity null exception");

            this.Entities.Remove(entity);
            await _db.SaveChangesAsync();

        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            if (!entities.Any()||entities == null)
                throw new ArgumentNullException("entity null exception");

            this.Entities.RemoveRange(entities);

            await _db.SaveChangesAsync();

        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity null exception");

            this.Entities.Update(entity);

            await _db.SaveChangesAsync();
        }
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_dbSet == null)
                    _dbSet = _db.Set<TEntity>();
                return _dbSet;
            }
        }
        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return this.Entities;
            }
        }

    }
}
