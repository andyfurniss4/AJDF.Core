using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Base
{
    public interface IAsyncRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where);
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> searchPredicate, int pageNumber, int pageSize);
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> searchPredicate, string columnToOrderBy, int pageNumber, int pageSize, bool orderByDescending = false);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<bool> InsertAsync(IEnumerable<TEntity> items);
        Task<bool> InsertAsync(TEntity item);

        Task<bool> UpdateAsync(IEnumerable<TEntity> items);
        Task<bool> UpdateAsync(TEntity item);

        Task<bool> InsertOrUpdateAsync(IEnumerable<TEntity> items);
        Task<bool> InsertOrUpdateAsync(TEntity item);

        Task<bool> DeleteAsync(IEnumerable<TEntity> items);
        Task<bool> DeleteAsync(TEntity item);
    }
}
