using CustomerAcquisition.Application.Commands;
using CustomerAcquisition.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAcquisition.Domain.Model
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public Document Document { get; internal set; }
        public Name Name { get; internal set; }
		  public Address Address { get; internal set; }

        internal Customer()
        {
            Id = Guid.NewGuid();
        }

        public static class Factory
        {
            public static Customer New(NewCustomerCommand command)
            {
                var customer = new Customer();
                customer.Name = new Name(command.Firstname, command.Lastname);
                customer.Document = new Document(command.Number);

                return customer;
            }
        }
    }
}
