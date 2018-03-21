using DAL.EntityFramework.Infrastructure;
using DAL.EntityFramework.Tests.Integration.Models;

namespace DAL.EntityFramework.Tests.Integration.Repositories
{
    public class TestEntityRepository : EFKeyedRepository<TestEntity, int>
    {
        public TestEntityRepository(IEFDatabaseContext context) : base(context)
        {
        }
    }
}
