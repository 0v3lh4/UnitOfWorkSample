using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.Unity;
using Infrastructure.Data.ConnectionRepository;

namespace Infrastructure.Data.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		readonly ICollection<object> _repositories;
		readonly IUnityContainer _container;
		readonly IConnectionRepository _connectionRepository;
		IDataContext _dapperContext;

		public UnitOfWork( IUnityContainer container, IConnectionRepository connection )
		{
			_container = container;
			_connectionRepository = connection;
			_repositories = new HashSet<object>();
		}

		public void Begin( IsolationLevel isolationLevel = IsolationLevel.ReadCommitted )
		{
			_dapperContext.BeginTransaction( isolationLevel );
		}

		public void Commit()
		{
			_dapperContext.Commit();
		}

		public void Dispose()
		{
			if( _dapperContext != null )
			{
				_dapperContext.Dispose();
			}
		}

		public T GetRepository<T>( string repositoryKey = null ) where T : class
		{
			if( _repositories.Any( rep => typeof( T ).IsInstanceOfType(rep) ) )
				return ( T )_repositories.Where( rep => typeof( T ).IsInstanceOfType(rep) ).First();

			createDapperContext( repositoryKey );

			var repository = _container.Resolve<T>( new ResolverOverride[] {
					 new ParameterOverride("context", _dapperContext)
				} );

			_repositories.Add( repository );

			return repository;
		}

		private void createDapperContext( string repositoryKey )
		{
			if( _dapperContext == null )
				_dapperContext = new DapperContext( _connectionRepository.GetConnectionString( repositoryKey ) );
		}

		public void Rollback()
		{
			_dapperContext.Rollback();
		}
	}
}
