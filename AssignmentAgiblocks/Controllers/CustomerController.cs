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
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            var companyItem = await _context.Customers.FindAsync(customerId);

            if (companyItem == null)
            {
                return NotFound();
            }

            return Ok(companyItem);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCostumer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomers), new { customerId = customer.CustomerId }, customer);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<Customer>> UploadFile(IFormFile file)
        {
            _customerService.UploadFile(file);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer item)
        {
            if (id != item.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
