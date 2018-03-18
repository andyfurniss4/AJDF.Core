using DAL.Base;
using DAL.Base.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework.Infrastructure
{
    public class EFUnitOfWork : Disposable, IUnitOfWork
    {
        private IDataContextFactory factory;

        public EFUnitOfWork(IDataContextFactory factory)
        {
            this.factory = factory;
        }

        public void Commit()
        {
            this.factory.Get().Commit();
        }

        public async Task CommitAsync()
        {
            await this.factory.Get().CommitAsync();
        }
    }
}
