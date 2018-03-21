using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using DAL.Base;
using DAL.Base.Repositories;
using DAL.DynamoDB.Helpers;
using DAL.DynamoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DynamoDB.Repositories
{
    public class DynamoDBKeyedRepository<TEntity, TKey> : DynamoDBRepositoryBase<TEntity>, IAsyncKeyedRepository<TEntity, TKey>
        where TEntity : DynamoDBEntity
        where TKey : struct
    {
        private readonly IAmazonDynamoDB client;

        public DynamoDBKeyedRepository(IDynamoDBContext context, IAmazonDynamoDB client) : base(context)
        {
            this.client = client;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            await DynamoDBHelper.AttemptOperation(async () => await this.DataContext.DeleteAsync<TEntity>(id));
            return true;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return (await DynamoDBHelper.AttemptOperation(async () => await this.DataContext.QueryAsync<TEntity>(id).GetNextSetAsync())).FirstOrDefault();
        }
    }
}
