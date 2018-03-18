using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using DAL.Base;
using DAL.DynamoDB.Helpers;
using DAL.DynamoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DynamoDB.Repositories
{
    public class DynamoDBRepositoryBase<TEntity> : IAsyncRepositoryBase<TEntity> where TEntity : DynamoDBEntity
    {
        protected readonly IDynamoDBContext DataContext;

        public DynamoDBRepositoryBase(IDynamoDBContext context)
        {
            this.DataContext = context;
        }

        public Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> searchPredicate, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> searchPredicate, string columnToOrderBy, int pageNumber, int pageSize, bool orderByDescending = false)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            //return await this.DataContext.QueryAsync(...);  // Use LinqToDynamoDB package here
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(TEntity item)
        {
            await this.InsertOrUpdateAsync(item);
            return true;
        }

        public async Task<bool> InsertAsync(IEnumerable<TEntity> items)
        {
            await this.InsertOrUpdateAsync(items);
            return true;
        }

        public async Task<bool> InsertOrUpdateAsync(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                await DynamoDBHelper.AttemptOperation(async () => await this.DataContext.SaveAsync(item));
            }
            return true;
        }

        public async Task<bool> InsertOrUpdateAsync(TEntity item)
        {
            await DynamoDBHelper.AttemptOperation(async () => await this.DataContext.SaveAsync(item));
            return true;
        }

        public async Task<bool> UpdateAsync(IEnumerable<TEntity> items)
        {
            await this.InsertOrUpdateAsync(items);
            return true;
        }

        public async Task<bool> UpdateAsync(TEntity item)
        {
            await this.InsertOrUpdateAsync(item);
            return true;
        }

        public async Task<bool> DeleteAsync(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                await DynamoDBHelper.AttemptOperation(async () => await this.DataContext.DeleteAsync(item));
            }
            return true;
        }

        public async Task<bool> DeleteAsync(TEntity item)
        {
            await DynamoDBHelper.AttemptOperation(async () => await this.DataContext.DeleteAsync(item));
            return true;
        }
    }
}
