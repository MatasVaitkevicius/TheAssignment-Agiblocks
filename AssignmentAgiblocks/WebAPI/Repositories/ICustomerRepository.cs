using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentAgiblocks.WebAPI.Models;

namespace AssignmentAgiblocks.WebAPI.Repositories
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
