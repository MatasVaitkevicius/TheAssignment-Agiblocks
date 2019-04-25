using AssignmentAgiblocks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AssignmentAgiblocks.Repositories
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
            customers.ToList().ForEach(c => Create(c));
            await SaveAsync();
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            Delete(customer);
            await SaveAsync();
        }
    }
}
