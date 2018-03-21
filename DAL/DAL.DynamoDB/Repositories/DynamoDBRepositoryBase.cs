using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DAL.Base.Repositories;
using DAL.DynamoDB.Helpers;
using DAL.DynamoDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DynamoDB.Repositories
{
    public class DynamoDBRepositoryBase<TEntity> : IAsyncCrudRepository<TEntity> where TEntity : DynamoDBEntity
    {
        protected readonly IDynamoDBContext DataContext;

        public DynamoDBRepositoryBase(IDynamoDBContext context)
        {
            this.DataContext = context;
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            var coniditions = new List<ScanCondition>();
            return await DynamoDBHelper.AttemptOperation(async () => await this.DataContext.ScanAsync<TEntity>(coniditions).GetRemainingAsync());
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
