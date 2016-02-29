using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.Unity;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ICollection<object> _repositories;
        readonly IUnityContainer _container;
        IDataContext _dapperContext;
        IDbTransaction _transaction;

        public UnitOfWork(IUnityContainer container, string connectionString)
        {
            _container = container;
            _repositories = new HashSet<object>();
            _dapperContext = new DapperContext(connectionString);
        }

        public void Begin(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = _dapperContext.Connection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _transaction.Commit();
            _transaction = null;
        }

        public void Dispose()
        {
            if(_transaction != null)
            {
                Commit();
            }

            _dapperContext.Dispose();
        }

        public T GetRepository<T>() where T : class
        {
            if(_repositories.Any(rep => rep.GetType() == typeof(T)))
                return (T)_repositories.Where(rep => rep.GetType() == typeof(T)).First();

            var repository = _container.Resolve<T>(new ResolverOverride[] {
                new ParameterOverride("context", _dapperContext)
            });

            _repositories.Add(repository);

            return repository;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }
    }
}
