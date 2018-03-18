using Amazon.DynamoDBv2.DataModel;
using DAL.DynamoDB.Repositories;
using DAL.DynamoDB.Tests.Integration.Models;

namespace DAL.DynamoDB.Tests.Integration.Repositories
{
    public class TestEntityRepository : DynamoDBRepositoryBase<TestEntity>
    {
        public TestEntityRepository(IDynamoDBContext context) : base(context)
        {
        }
    }
}
