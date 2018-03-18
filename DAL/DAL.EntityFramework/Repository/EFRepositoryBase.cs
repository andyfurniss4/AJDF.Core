using DAL.Base;
using DAL.EntityFramework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.EntityFramework
{
    public class EFRepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        protected IEFDatabaseContext dataContext;
        protected readonly DbSet<T> dbSet;

        protected IDataContextFactory DatabaseFactory { get; private set; }
        protected IEFDatabaseContext DataContext
            => dataContext ?? (dataContext = (IEFDatabaseContext)DatabaseFactory.Get());

        protected EFRepositoryBase(IDataContextFactory databaseFactory)
        {
            this.DatabaseFactory = databaseFactory;
            this.dbSet = this.DataContext.Set<T>();
        }

        public T FindOne(Expression<Func<T, bool>> where)
            => this.dbSet.Where(where).FirstOrDefault();

        public T FindOneWithRelations(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] relations)
        {
            var query = this.dbSet.Where(where);
            foreach (var relation in relations)
            {
                query = query.Include(relation);
            }

            return query.FirstOrDefault();
        }

        public ICollection<T> Find(Expression<Func<T, bool>> where)
            => this.dbSet.Where(where).ToList();

        public IQueryable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] relations)
        {
            var query = this.dbSet.Where(where);
            foreach (var relation in relations)
            {
                query = query.Include(relation);
            }

            return query;
        }

        public ICollection<T> Find(Expression<Func<T, bool>> where, int pageNumber, int pageSize)
            => this.dbSet.Where(where).Skip(pageNumber * pageSize).Take(pageSize).ToList();

        public ICollection<T> Find(Expression<Func<T, bool>> where, string columnToOrderBy, int pageNumber, int pageSize, bool orderByDescending = false)
        {
            Expression<Func<T, object>> orderByFunc = x => x.GetType().GetProperty(columnToOrderBy).GetValue(x, null);
            var query = this.dbSet.Where(where);

            query = orderByDescending ? query.OrderByDescending(orderByFunc) : query.OrderBy(orderByFunc);

            return query.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }

        public ICollection<T> GetAll()
            => this.dbSet.ToList();

        public ICollection<T> GetAll(params Expression<Func<T, object>>[] relations)
        {
            var query = this.dbSet.AsQueryable();
            foreach (var relation in relations)
            {
                query = query.Include(relation);
            }                

            return query.ToList();
        }

        public bool Insert(IEnumerable<T> items)
        {
            this.dbSet.AddRange(items);
            return true;
        }

        public bool Insert(T item)
        {
            if (item != null)
            {
                this.dbSet.Add(item);
                return true;
            }
            return false;
        }

        public bool Update(IEnumerable<T> items)
        {
            this.dbSet.UpdateRange(items);
            return true;
        }

        public bool Update(T item)
        {
            if (item != null)
            {
                this.dbSet.Attach(item);
                dataContext.Entry(item).State = EntityState.Modified;
                return true;
            }
            return false;
        }

        public bool InsertOrUpdate(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public bool InsertOrUpdate(T item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IEnumerable<T> items)
        {
            this.dbSet.RemoveRange(items);
            return true;
        }

        public bool Delete(T item)
        {
            this.dbSet.Remove(item);
            return true;
        }
    }
}
