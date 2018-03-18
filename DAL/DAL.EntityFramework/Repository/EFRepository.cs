using DAL.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class EFRepository<TEntity, TKey> : EFRepositoryBase<TEntity>, IRepository<TEntity, TKey> where TEntity : class, IEntity
    {
        public EFRepository(IDataContextFactory factory) 
            : base(factory)
        {
        }

        public TEntity GetByKey(TKey id)
            => this.dbSet.Find(id);

        public TEntity GetById(Expression<Func<TEntity, bool>> where)
            => this.dbSet.Where(where).SingleOrDefault();

        public bool Delete(TKey id)
        {
            var entity = this.dbSet.Find(id);
            this.dbSet.Remove(entity);
            return true;
        }
    }
}
