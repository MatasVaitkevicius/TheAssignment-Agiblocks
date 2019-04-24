using AssignmentAgiblocks.BusinessLayer;
using AssignmentAgiblocks.Models;
using AssignmentAgiblocks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            await _customerService.GetCustomerById(customerId);

            return Ok(_customerService.GetCustomerById(customerId));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            await _customerService.UploadFile(file);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteCustomer(int id)
        {
            await _customerService.RemoveCustomer(id);
        }
    }
}
