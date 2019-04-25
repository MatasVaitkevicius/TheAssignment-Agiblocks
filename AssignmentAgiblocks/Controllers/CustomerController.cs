using AssignmentAgiblocks.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var customers = await _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some error in the GetAllCustomers method: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);

                if (customer == null)
                {
                    Console.WriteLine($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    Console.WriteLine($"Returned customer with id: {id}");
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside GetCustomerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                await _customerService.UploadFile(file);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside UploadFile action {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    Console.WriteLine($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await _customerService.RemoveCustomer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside RemoveCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
