using AssignmentAgiblocks.Models;
using AssignmentAgiblocks.Repositories;
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

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task UploadFile(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var line = reader.ReadLineAsync().Result;
                line = reader.ReadLineAsync().Result;
                while (line != null)
                {
                    var values = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    await _customerRepository.CreateCustomerAsync(new Customer() { CounterPartID = values[0], CompanyName = values[1], IsBuyer = values[2], IsSeller = values[3], Phone = values[4], Fax = values[5] });
                    line = reader.ReadLineAsync().Result;
                }
            }
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
