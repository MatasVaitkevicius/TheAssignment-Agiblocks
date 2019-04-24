using AssignmentAgiblocks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.BusinessLayer
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task UploadFile(IFormFile file);
        Task GetCustomerById(int id);
        Task RemoveCustomer(int id);
    }
}
