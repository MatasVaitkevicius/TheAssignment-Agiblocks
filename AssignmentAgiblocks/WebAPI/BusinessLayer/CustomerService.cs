using AssignmentAgiblocks.Models;
using AssignmentAgiblocks.Repositories;
using AssignmentAgiblocks.WebAPI.Parser;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.BusinessLayer
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        private IParserFactory _filerParserFactory;

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
