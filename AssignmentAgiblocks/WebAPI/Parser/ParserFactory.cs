using System;
using System.Collections.Generic;
using System.IO;
using AssignmentAgiblocks.Models;
using Microsoft.AspNetCore.Http;

namespace AssignmentAgiblocks.WebAPI.Parser
{
    public static class FileExtensions
    {
        public const string XML = ".xml";
        public const string CSV = ".csv";
        public const string XLSX = ".xlsx";
    }

    public class ParserFactory : IParserFactory
    {
        public IParser BuildFileParser(string fileExtension)
        {
            switch (fileExtension)
            {
                case FileExtensions.CSV:
                    return new ParseCSV();
                case FileExtensions.XML:
                    return new ParseXML();
                case FileExtensions.XLSX:
                    return new ParseXLSX();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public class ParseCSV : IParser
    {
        public IEnumerable<Customer> ParseFile(IFormFile formFile)
        {
            var customers = new List<Customer>();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
                var line = reader.ReadLineAsync().Result;
                line = reader.ReadLineAsync().Result;
                while (line != null)
                {
                    var values = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    customers.Add(new Customer()
                    {
                        CounterPartID = values[0],
                        CompanyName = values[1],
                        IsBuyer = values[2],
                        IsSeller = values[3],
                        Phone = values[4],
                        Fax = values[5]
                    });
                    line = reader.ReadLineAsync().Result;
                }
            }

            return customers;
        }
    }

    public class ParseXML : IParser
    {
        public IEnumerable<Customer> ParseFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }

    public class ParseXLSX : IParser
    {
        public IEnumerable<Customer> ParseFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
