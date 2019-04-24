﻿using AssignmentAgiblocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task CreateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
    }
}