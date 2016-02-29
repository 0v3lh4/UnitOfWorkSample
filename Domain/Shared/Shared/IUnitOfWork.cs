using System;
using System.Data;

namespace Shared
{
    public interface IUnitOfWork : IDisposable
    {
        T GetRepository<T>(string repositoryKey = null) where T : class;
        void Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }
}