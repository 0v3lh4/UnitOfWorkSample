using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConnectionRepository
{
	public class HashTableConnectionRepository : IConnectionRepository
	{
		private Hashtable _hashTable;

		public HashTableConnectionRepository()
		{
			_hashTable = new Hashtable();
		}

		public string GetConnectionString( string repositoryKey )
		{
            var repositoryKeyUpper = repositoryKey.ToUpper();

            return _hashTable.ContainsKey(repositoryKeyUpper) ? _hashTable[repositoryKeyUpper].ToString() : "";
		}

		public void Save( string connectionString, string repositoryKey )
		{
            var repositoryKeyUpper = repositoryKey.ToUpper();

            if (_hashTable.ContainsKey( repositoryKeyUpper ))
                _hashTable[repositoryKeyUpper] = connectionString;
			else
                _hashTable.Add(repositoryKeyUpper, connectionString);
		}
	}
}
