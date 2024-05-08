using Assessment3.Models;

namespace Assessment3.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(string customerId);
        IEnumerable<Customer> GetCustomersByOrderDate(DateTime orderDate);
    }
}

