using System;
namespace AssignmentAgiblocks.WebAPI.Parser
{
    public interface IParserFactory
    {
        IParser BuildFileParser(string fileExtension);
    }
}
