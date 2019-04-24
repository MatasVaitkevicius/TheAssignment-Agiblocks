using AssignmentAgiblocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await FindAllAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var owner = await FindByConditionAsync(o => o.CustomerId.Equals(customerId));
            return owner.DefaultIfEmpty(new Customer())
                    .FirstOrDefault();
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            Create(customer);
            await SaveAsync();
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            Delete(customer);
            await SaveAsync();
        }
    }
}
