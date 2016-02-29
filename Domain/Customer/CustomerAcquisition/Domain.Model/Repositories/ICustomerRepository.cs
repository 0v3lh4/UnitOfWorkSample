using CustomerAcquisition.Domain.Model;

namespace CustomerAcquisition.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
    }
}