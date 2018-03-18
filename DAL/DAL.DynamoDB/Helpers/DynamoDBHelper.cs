using Amazon.DynamoDBv2;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DynamoDB.Helpers
{
    public static class DynamoDBHelper
    {
        public async static Task AttemptOperation(Func<Task> task)
        {
            try
            {
                await task();
            }
            catch (AmazonDynamoDBException ex)
            {
                // TODO: Add logging here
                throw;
            }
            catch (AmazonClientException ex)
            {
                // TODO: Add logging here
                throw;
            }
        }

        public async static Task<T> AttemptOperation<T>(Func<Task<T>> task)
        {
            var result = default(T);
            try
            {
                result = await task();
            }
            catch (AmazonDynamoDBException ex)
            {
                // TODO: Add logging here
                throw;
            }
            catch (AmazonClientException ex)
            {
                // TODO: Add logging here
                throw;
            }

            return result;
        }
    }
}
