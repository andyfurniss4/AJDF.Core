using DAL.Base;
using DAL.Base.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EntityFramework.Infrastructure
{
    public class EFDataContextFactory : Disposable, IDataContextFactory
    {
        private IEFDatabaseContext dataContextEF;
        private string connectionString;

        public EFDataContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool HasEFContext => dataContextEF != null;

        public IDbContext Get()
        {
            if (dataContextEF != null)
                return dataContextEF;

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);

            return dataContextEF = new EFDatabaseContext(optionsBuilder.Options);
        }
    }
}
