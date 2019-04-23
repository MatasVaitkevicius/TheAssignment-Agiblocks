using AssignmentAgiblocks.Models;
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
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(long counterPartID)
        {
            var companyItem = await _context.Customer.FindAsync(counterPartID);

            if (companyItem == null)
            {
                return NotFound();
            }

            return companyItem;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCostumer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomers), new { customerId = customer.CustomerId }, customer);
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<Customer>> UploadFile(IFormFile file)
        {

            string sFileExtension = Path.GetExtension(file.FileName).ToLower();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var line = reader.ReadLineAsync().Result;
                line = reader.ReadLineAsync().Result;
                while (line != null)
                {
                    var values = line.Split(",");
                    var counterPartID = values[0];
                    var name = values[1];
                    var isBuyer = values[2];
                    var isSeller = values[3];
                    var phone = values[4];
                    var fax = values[5];

                    _context.Customer.Add(new Customer(counterPartID, name, isBuyer, isSeller, phone, fax));
                    await _context.SaveChangesAsync();
                    line = reader.ReadLineAsync().Result;
                }
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer item)
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
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var companyItem = await _context.Customer.FindAsync(id);

            if (companyItem == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(companyItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
