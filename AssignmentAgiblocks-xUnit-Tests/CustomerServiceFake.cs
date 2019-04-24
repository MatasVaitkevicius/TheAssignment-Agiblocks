using AssignmentAgiblocks.BusinessLayer;
using AssignmentAgiblocks.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentAgiblocks_xUnit_Tests
{
    public class CustomerServiceFake : ICustomerService
    {
        private readonly List<Customer> _customer;

        public CustomerServiceFake()
        {
            _customer = new List<Customer>()
            {new Customer(){ CustomerId = 36, CounterPartID = "B10036", CompanyName = "Test Company 36", IsBuyer = "Yes", IsSeller = "No", Phone = "3165656667", Fax = "319889808" },
            new Customer(){ CustomerId = 8, CounterPartID = "B1008", CompanyName = "Test Company 8", IsBuyer = "Yes", IsSeller = "Yes", Phone = "3165656667", Fax = "319889808" },
            new Customer(){ CustomerId = 40, CounterPartID = "B10040", CompanyName = "Test Company 40", IsBuyer = "Yes", IsSeller = "No", Phone = "3165656667", Fax = "319889808" },
            };
        }

        IEnumerable<Customer> ICustomerService.GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        Customer ICustomerService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        void ICustomerService.Remove(int id)
        {
            throw new NotImplementedException();
        }

        void ICustomerService.UploadFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
