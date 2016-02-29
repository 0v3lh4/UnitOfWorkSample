using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public interface IDataContext : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
		  IDbTransaction BeginTransaction( IsolationLevel isolationLevel = IsolationLevel.ReadCommitted );
		  void Commit();
		  void Rollback();
    }
}
