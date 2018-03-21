using DAL.Base;
using DAL.Base.Repositories;
using DAL.EntityFramework.Infrastructure;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.EntityFramework
{
    public class EFKeyedRepository<TEntity, TKey> : EFRepositoryBase<TEntity>, IKeyedRepository<TEntity, TKey>, IKeyedLinqRepository<TEntity>
        where TEntity : class, IEntity
        where TKey : struct
    {
        public EFKeyedRepository(IEFDatabaseContext context) 
            : base(context)
        {
        }

        public TEntity GetById(TKey id)
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
