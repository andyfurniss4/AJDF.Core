using Amazon.DynamoDBv2.DataModel;
using DAL.Base;
using System;

namespace DAL.DynamoDB.Models
{
    public abstract class DynamoDBEntity : IEntity
    {
        [DynamoDBHashKey]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] Version { get; set; }
    }
}
