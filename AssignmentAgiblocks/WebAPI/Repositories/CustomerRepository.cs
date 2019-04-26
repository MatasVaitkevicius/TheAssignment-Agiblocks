using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentAgiblocks.WebAPI.Models;

namespace AssignmentAgiblocks.WebAPI.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await FindByExpression(o => o.CustomerId.Equals(customerId));
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            Create(customer);
            await SaveAsync();
        }

        public async Task CreateCustomersAsync(IEnumerable<Customer> customers)
        {
            customers.ToList().ForEach(Create);
            await SaveAsync();
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            Delete(customer);
            await SaveAsync();
        }
    }
}
