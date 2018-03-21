using System.Collections.Generic;

namespace DAL.Base.Repositories
{
    public interface ICrudRepository<TEntity> where TEntity : class, IEntity
    {
        ICollection<TEntity> GetAll();

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
