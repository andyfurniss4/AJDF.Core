using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Base
{
    public interface IRepository<TEntity, TKey> : IRepositoryBase<TEntity> where TEntity : IEntity
    {
        TEntity GetByKey(TKey Id);
        TEntity GetById(Expression<Func<TEntity, bool>> searchPred);
        bool Delete(TKey id);
    }
}
