using System;
using System.Collections.Generic;
using System.IO;
using AssignmentAgiblocks.WebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace AssignmentAgiblocks.WebAPI.Parser
{
    public class ParseCsv : IParser
    {
        public IEnumerable<Customer> ParseFile(IFormFile formFile)
        {
            var customers = new List<Customer>();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
                var line = reader.ReadLineAsync().Result;
                while ((line = reader.ReadLineAsync().Result) != null)
                {
                    var values = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    customers.Add(new Customer
                    {
                        CounterPartId = values[0],
                        CompanyName = values[1],
                        IsBuyer = values[2],
                        IsSeller = values[3],
                        Phone = values[4],
                        Fax = values[5]
                    });
                }
            }

            return customers;
        }
    }
}
