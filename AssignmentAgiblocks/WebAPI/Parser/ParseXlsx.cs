using System;
using System.Collections.Generic;
using AssignmentAgiblocks.WebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace AssignmentAgiblocks.WebAPI.Parser
{
    public class ParseXlsx : IParser
    {
        public IEnumerable<Customer> ParseFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}