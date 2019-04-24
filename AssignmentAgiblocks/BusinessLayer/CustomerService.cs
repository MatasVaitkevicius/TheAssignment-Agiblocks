using AssignmentAgiblocks.Models;
using AssignmentAgiblocks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void UploadFile(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var line = reader.ReadLineAsync().Result;
                line = reader.ReadLineAsync().Result;
                while (line != null)
                {
                    var values = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    _customerRepository.Create(new Customer() { CounterPartID = values[0], CompanyName = values[1], IsBuyer = values[2], IsSeller = values[3], Phone = values[4], Fax = values[5] });
                    line = reader.ReadLineAsync().Result;
                }
                _customerRepository.Save();
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.FindAll();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
