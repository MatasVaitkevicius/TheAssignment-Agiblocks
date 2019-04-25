using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentAgiblocks.WebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace AssignmentAgiblocks.WebAPI.BusinessLayer
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task UploadFile(IFormFile file);
        Task<Customer> GetCustomerById(int id);
        Task RemoveCustomer(int id);
    }
}
