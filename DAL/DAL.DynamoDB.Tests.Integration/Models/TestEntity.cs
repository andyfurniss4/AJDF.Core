using Amazon.DynamoDBv2.DataModel;
using DAL.DynamoDB.Models;

namespace DAL.DynamoDB.Tests.Integration.Models
{
    [DynamoDBTable("TestEntities")]
    public class TestEntity : DynamoDBEntity
    {
        public string Name { get; set; }
    }
}
