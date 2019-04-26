using System.Threading.Tasks;
using AssignmentAgiblocks.WebAPI.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AssignmentAgiblocks.WebAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            _logger.LogInformation("Returned all customers");
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {

            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
            {
                _logger.LogWarning($"Customer with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            _logger.LogInformation($"Returned customer with id: {id}");
            return Ok(customer);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            await _customerService.UploadFile(file);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {

            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                _logger.LogWarning($"Customer with id: {id}, hasn't been found in db.");
                return NotFound();
            }

            await _customerService.RemoveCustomer(id);
            _logger.LogInformation($"Customer with id: {id}, has been removed");
            return NoContent();
        }
    }
}
