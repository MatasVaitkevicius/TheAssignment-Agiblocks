using AssignmentAgiblocks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task CreateCustomerAsync(Customer customer);
        Task CreateCustomersAsync(IEnumerable<Customer> customers);
        Task DeleteCustomerAsync(Customer customer);
    }
}
