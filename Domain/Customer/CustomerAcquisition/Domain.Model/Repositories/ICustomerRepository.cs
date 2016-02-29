using CustomerAcquisition.Domain.Model;

namespace CustomerAcquisition.Domain.Model.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
    }
}