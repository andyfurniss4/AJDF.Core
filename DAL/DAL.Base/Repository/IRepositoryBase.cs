using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : IEntity
    {
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> searchPredicate, int pageNumber, int pageSize);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> searchPredicate, string columnToOrderBy, int pageNumber, int pageSize, bool orderByDescending = false);

        TEntity Get(Expression<Func<TEntity, bool>> where);
        ICollection<TEntity> GetAll();
        ICollection<TEntity> GetAllAsync();
        ICollection<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
        ICollection<TEntity> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);

        bool Insert(IEnumerable<TEntity> items);
        bool Insert(TEntity item);

        bool Update(IEnumerable<TEntity> items);
        bool Update(TEntity item);

        bool InsertOrUpdate(IEnumerable<TEntity> items);
        bool InsertOrUpdate(TEntity item);

        bool Delete(IEnumerable<TEntity> items);
        bool Delete(TEntity item);
    }
}
