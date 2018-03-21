using System;
using System.Linq.Expressions;

namespace DAL.Base.Repositories
{
    public interface IKeyedLinqRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetById(Expression<Func<TEntity, bool>> where);
    }
}
