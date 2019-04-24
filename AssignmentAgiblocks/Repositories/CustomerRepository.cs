using AssignmentAgiblocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext)
            :base(customerContext)
        {
        }
    }
}
