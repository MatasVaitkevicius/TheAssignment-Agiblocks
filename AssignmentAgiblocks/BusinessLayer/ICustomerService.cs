using AssignmentAgiblocks.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.BusinessLayer
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task UploadFile(IFormFile file);
        Task<Customer> GetCustomerById(int id);
        Task RemoveCustomer(int id);
    }
}
