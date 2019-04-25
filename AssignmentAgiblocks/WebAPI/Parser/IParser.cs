using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using AssignmentAgiblocks.WebAPI.Models;

namespace AssignmentAgiblocks.WebAPI.Parser
{
    public interface IParser
    {
        IEnumerable<Customer> ParseFile(IFormFile formFile);
    }
}
