using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Infrastructure
{
    public partial class EFDatabaseContext : DbContext, IEFDatabaseContext
    {
        public EFDatabaseContext(DbContextOptions options) : base(options)
        {
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
