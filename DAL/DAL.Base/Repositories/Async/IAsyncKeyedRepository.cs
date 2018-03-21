using System.Threading.Tasks;

namespace DAL.Base.Repositories
{
    public interface IAsyncKeyedRepository<TEntity, TKey>
        where TEntity : class, IEntity
        where TKey : struct
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<bool> DeleteAsync(TKey id);
    }
}
