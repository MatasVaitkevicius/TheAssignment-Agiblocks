using System;

namespace AssignmentAgiblocks.WebAPI.Parser
{
    public static class FileExtensions
    {
        public const string Xml = ".xml";
        public const string Csv = ".csv";
        public const string Xlsx = ".xlsx";
    }

    public class ParserFactory : IParserFactory
    {
        public IParser BuildFileParser(string fileExtension)
        {
            switch (fileExtension)
            {
                case FileExtensions.Csv:
                    return new ParseCsv();
                case FileExtensions.Xml:
                    return new ParseXml();
                case FileExtensions.Xlsx:
                    return new ParseXlsx();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
