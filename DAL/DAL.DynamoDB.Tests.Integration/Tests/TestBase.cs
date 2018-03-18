using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Ninject;
using NUnit.Framework;

namespace DAL.DynamoDB.Tests.Integration.Tests
{
    [SetUpFixture]
    public partial class TestBase
    {
        protected IKernel Kernel;

        [OneTimeSetUp]
        public void TestInitialise()
        {
            Kernel = new StandardKernel();

            Kernel.Bind<IAmazonDynamoDB>().To<AmazonDynamoDBClient>().InSingletonScope().WithConstructorArgument("region", RegionEndpoint.EUWest2);
            Kernel.Bind<IDynamoDBContext>().To<DynamoDBContext>().InSingletonScope();
        }
    }
}
