using DAL.Base.Infrastructure;

namespace DAL.Base
{
    public interface IDataContextFactory
    {
        IDbContext Get();
        bool HasEFContext { get; }
    }
}
