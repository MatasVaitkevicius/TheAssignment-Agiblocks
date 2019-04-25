using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AssignmentAgiblocks.WebAPI.Models;
using AssignmentAgiblocks.WebAPI.Parser;
using AssignmentAgiblocks.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;

namespace AssignmentAgiblocks.WebAPI.BusinessLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IParserFactory _filerParserFactory;

        public CustomerService(ICustomerRepository customerRepository, IParserFactory filerParserFactory)
        {
            _customerRepository = customerRepository;
            _filerParserFactory = filerParserFactory;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task UploadFile(IFormFile file)
        {  
            var parser = _filerParserFactory.BuildFileParser(Path.GetExtension(file.FileName));
            var customers = parser.ParseFile(file);
            await _customerRepository.CreateCustomersAsync(customers);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task RemoveCustomer(int id)
        {
            await _customerRepository.DeleteCustomerAsync(await _customerRepository.GetCustomerByIdAsync(id));
        }
    }
}
