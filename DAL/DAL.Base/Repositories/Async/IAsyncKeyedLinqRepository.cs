using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Base.Repositories
{
    public interface IAsyncKeyedLinqRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> where);
    }
}
