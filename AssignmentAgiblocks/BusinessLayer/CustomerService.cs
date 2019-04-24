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

        public async Task GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(id);

                if (customer  == null)
                {
                    Console.WriteLine($"Owner with id: {id}, hasn't been found in db.");
                    //return NotFound();
                }
                else
                {
                    Console.WriteLine($"Returned owner with id: {id}");
                    //return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside GetOwnerById action: {ex.Message}");
                //return HttpContext.Response.StatusCode(500, "Internal server error");
            }
        }

        public async Task RemoveCustomer(int id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    //Console.WriteLine($"Owner with id: {id}, hasn't been found in db.");
                    //return NotFound();
                }

                await _customerRepository.DeleteCustomerAsync(customer);

               // return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong inside DeleteOwner action: {ex.Message}");
               // return StatusCode(500, "Internal server error");
            }
        }
    }
}
