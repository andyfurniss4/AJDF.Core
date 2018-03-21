using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Base.Repositories
{
    public interface IAsyncCrudRepository<TEntity> where TEntity : class, IEntity
    {
        Task<ICollection<TEntity>> GetAllAsync();

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
