using System;
using System.Linq.Expressions;

namespace DAL.Base
{
    public interface IRepository<TEntity, TKey> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        TEntity GetByKey(TKey id);
        TEntity GetById(Expression<Func<TEntity, bool>> where);
        bool Delete(TKey id);
    }
}
