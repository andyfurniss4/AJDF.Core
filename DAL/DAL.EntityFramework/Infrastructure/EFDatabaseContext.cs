using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Infrastructure
{
    public partial class EFDatabaseContext : DbContext, IEFDatabaseContext
    {
        public Guid Id { get; private set; }

        public EFDatabaseContext(DbContextOptions options) : base(options)
        {
            this.Id = Guid.NewGuid();
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
