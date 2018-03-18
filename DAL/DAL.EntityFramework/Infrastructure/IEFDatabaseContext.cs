using DAL.Base.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DAL.EntityFramework.Infrastructure
{
    public interface IEFDatabaseContext : IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry Entry(object entity);
        DatabaseFacade Database { get; }
    }
}
