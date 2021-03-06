﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Data.Repositories
{
    public class DapperContext : IDataContext
    {
        readonly string _connectionString;
        IDbConnection _connection;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

		public IDbTransaction Transaction { get; set; }

		public IDbConnection Connection {
            get
            {
                if(_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                return _connection;
            }
        }

		public void Dispose()
        {
            if(_connection != null)
            {
					if( Transaction != null )
					{
						Commit();
					}

               if(_connection.State == ConnectionState.Open)
               {
                   _connection.Close();
                   _connection.Dispose();
               }
            }
        }

		public IDbTransaction BeginTransaction( IsolationLevel isolationLevel = IsolationLevel.ReadCommitted )
		{
			return Transaction = Connection.BeginTransaction( isolationLevel );
		}

		public void Commit()
		{
			if( Transaction != null )
			{
				Transaction.Commit();
				Transaction = null;
			}
		}

		public void Rollback()
		{
			if( Transaction != null )
			{
				Transaction.Rollback();
				Transaction = null;
			}
		}
	}
}