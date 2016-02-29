using CustomerAcquisition.Application.Commands;
using CustomerAcquisition.Domain.Model;
using CustomerAcquisition.Repositories;
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
            var repository = _unitOfWork.GetRepository<ICustomerRepository>();
            repository.Save(customer);
        }
    }
}
