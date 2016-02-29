using CustomerAcquisition.Application.Commands;
using CustomerAcquisition.Domain.Model;
using CustomerAcquisition.Domain.Model.Repositories;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAcquisition.Application
{
    public class CustomerService
    {
        readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCustomer(NewCustomerCommand command)
        {
            var customer = Customer.Factory.New(command);
            var customerRepository = _unitOfWork.GetRepository<ICustomerRepository>(command.RepositoryKey);
				var addressRepository = _unitOfWork.GetRepository<IAddressRepository>();

			try
			{
				_unitOfWork.Begin( System.Data.IsolationLevel.ReadUncommitted );
            customerRepository.Save(customer);
				addressRepository.Save(Guid.NewGuid(), customer.Address );
				_unitOfWork.Commit();
			}
			catch( Exception ex)
			{
				_unitOfWork.Rollback();
			}
			finally
			{
				_unitOfWork.Dispose();
			}
        }
    }
}
