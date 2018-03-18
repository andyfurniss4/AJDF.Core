using DAL.EntityFramework.Infrastructure;
using DAL.EntityFramework.Tests.Integration.Models;

namespace DAL.EntityFramework.Tests.Integration.Repositories
{
    public class TestEntityRepository : EFRepository<TestEntity, int>
    {
        public TestEntityRepository(IEFDatabaseContext context) : base(context)
        {
        }
    }
}
