using System;
using System.Threading.Tasks;

namespace DAL.Base.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
