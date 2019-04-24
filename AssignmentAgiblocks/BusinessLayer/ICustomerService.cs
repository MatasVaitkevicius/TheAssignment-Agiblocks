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
        IEnumerable<Customer> GetAllCustomers();
        void UploadFile(IFormFile file);
        Customer GetById(int id);
        Task<IActionResult> Remove(int id);
    }
}
