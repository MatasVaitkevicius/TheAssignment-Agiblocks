using AssignmentAgiblocks.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AssignmentAgiblocks.WebAPI.Parser
{
    public interface IParser
    {
        IEnumerable<Customer> ParseFile(IFormFile formFile);
    }
}
