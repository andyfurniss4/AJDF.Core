using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DAL.Base;
using DAL.DynamoDB.Tests.Integration.Models;
using DAL.DynamoDB.Tests.Integration.Repositories;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DynamoDB.Tests.Integration.Tests
{
    [TestFixture]
    public class TestEntityRepositoryTests : TestBase
    {
        private readonly string testEntityTableName = "TestEntities";
        private IAmazonDynamoDB amazonClient;
        private TestEntityRepository repository;

        [OneTimeSetUp]
        public async Task Initialise()
        {
            this.amazonClient = Kernel.Get<IAmazonDynamoDB>();
            var createTableRequest = new CreateTableRequest
            {
                TableName = this.testEntityTableName,
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition { AttributeName = "Id", AttributeType = "N" }
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement { AttributeName = "Id", KeyType = "HASH" }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 3,
                    WriteCapacityUnits = 1
                }
            };

            var createTableResponse = await this.amazonClient.CreateTableAsync(createTableRequest);

            var tableStatus = "";
            do
            {
                try
                {
                    var checkTableResponse = await this.amazonClient.DescribeTableAsync(this.testEntityTableName);
                    tableStatus = checkTableResponse.Table.TableStatus;
                }
                catch (ResourceNotFoundException)
                {
                }
            } while (tableStatus != TableStatus.ACTIVE);
        }

        [SetUp]
        public void Setup()
        {
            this.repository = Kernel.Get<TestEntityRepository>();
        }

        [Test]
        [Category("DAL.DynamoDb.Integration")]
        public async Task InsertSucceeds_ReturnsTrue()
        {
            // Arrange
            var date = DateTime.Now.Date;
            var entity = new TestEntity
            {
                Id = 1,
                Name = "Test Entity",
                CreatedDate = date
            };

            // Act
            var result = await this.repository.InsertAsync(entity);

            // Assert
            Assert.IsTrue(result);
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await this.deleteTestTable();
        }

        private async Task deleteTestTable()
        {
            try
            {
                await this.amazonClient.DeleteTableAsync(this.testEntityTableName);
            }
            catch (ResourceNotFoundException)
            {
            }            
        }
    }
}
