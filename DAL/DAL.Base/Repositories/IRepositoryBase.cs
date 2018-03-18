using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        TEntity FindOne(Expression<Func<TEntity, bool>> where);
        TEntity FindOneWithRelations(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] relations);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> where);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> where, int pageNumber, int pageSize);
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> where, string columnToOrderBy, int pageNumber, int pageSize, bool orderByDescending = false);

        ICollection<TEntity> GetAll();
        ICollection<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

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
