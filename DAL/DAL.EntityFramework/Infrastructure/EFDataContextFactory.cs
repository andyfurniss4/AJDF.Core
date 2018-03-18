using DAL.Base;
using DAL.Base.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EntityFramework.Infrastructure
{
    public class EFDataContextFactory : Disposable, IDataContextFactory
    {
        private IEFDatabaseContext dataContext;
        private DbContextOptions options;

        public EFDataContextFactory(DbContextOptions options)
        {
            this.options = options;
        }

        public bool HasEFContext
            => dataContext != null;

        public IDbContext Get()
            => dataContext ?? (dataContext = new EFDatabaseContext(options));
    }
}
