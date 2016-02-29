using CustomerAcquisition.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAcquisition.Domain.Model.Repositories
{
	public interface IAddressRepository
	{
        void Save(Guid customerId, Address address);
	}
}
