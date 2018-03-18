using DAL.EntityFramework.Infrastructure;
using DAL.EntityFramework.Tests.Integration.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Tests.Integration.Infrastructure
{
    public class TestDataContext : EFDatabaseContext
    {
        public TestDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
