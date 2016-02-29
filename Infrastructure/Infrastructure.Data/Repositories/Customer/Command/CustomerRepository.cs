using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAcquisition.Domain.Model;
using Dapper;
using CustomerAcquisition.Domain.Model.Repositories;

namespace Infrastructure.Data.Repositories.Customer.Command
{
	public class CustomerRepository : ICustomerRepository
	{
		private IDataContext _context;

		public CustomerRepository(IDataContext context)
		{
			_context = context;
		}

		public void Save( CustomerAcquisition.Domain.Model.Customer customer )
		{
			_context.Connection.Execute( "insert Customer(id, number, firstname, lastname) values(@id, @number, @firstname, @lastname)",
				new
				{
					id = customer.Id,
					number = customer.Document.NumberOriginal,
					firstname = customer.Name.Firstname,
					lastname = customer.Name.LastName
				}, _context.Transaction );
		}
	}
}
