using CustomerAcquisition.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAcquisition.Domain.Model.ValueObjects;
using Dapper;

namespace Infrastructure.Data.Repositories.Customer.Command
{
	public class AddressRepository : IAddressRepository
	{
		readonly IDataContext _context;

		public AddressRepository(IDataContext context)
		{
			_context = context;
		}

		public void Save(Guid customerId, Address address )
		{
			_context.Connection.Execute( "insert Address(customerid, line1, line2, code) values(@customerId, @line1, @line2, @code)",
				new
				{
					customerId = customerId,
					line1 = address.AddressLine,
					line2 = address.AddressLine2,
					code = address.Code
				}, _context.Transaction );
		}
	}
}
