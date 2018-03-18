using DAL.Base.Infrastructure;
using System.Threading.Tasks;

namespace DAL.EntityFramework.Infrastructure
{
    public class EFUnitOfWork : Disposable, IUnitOfWork
    {
        private IEFDatabaseContext context;

        public EFUnitOfWork(IEFDatabaseContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.Commit();
        }

        public async Task CommitAsync()
        {
            await this.context.CommitAsync();
        }
    }
}
