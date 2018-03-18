using System;
using System.Threading.Tasks;

namespace DAL.Base.Infrastructure
{
    public interface IDbContext : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
