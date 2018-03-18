using DAL.Base;
using DAL.Base.Infrastructure;
using System;

namespace DAL.DynamoDB.Infrastructure
{
    public class DynamoDatabaseFactory : IDataContextFactory
    {
        public bool HasEFContext => throw new NotImplementedException();

        public IDbContext Get()
        {
            throw new NotImplementedException();
        }
    }
}
