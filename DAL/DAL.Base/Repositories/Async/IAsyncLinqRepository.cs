using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Base.Repositories
{
    public interface IAsyncLinqRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> FindOne(Expression<Func<TEntity, bool>> where);
        Task<TEntity> FindOneWithRelations(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] relations);
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where);
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> searchPredicate, int pageNumber, int pageSize);
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> searchPredicate, string columnToOrderBy, int pageNumber, int pageSize, bool orderByDescending = false);

        Task<ICollection<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
