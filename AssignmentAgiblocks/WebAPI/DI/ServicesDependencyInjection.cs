using AssignmentAgiblocks.WebAPI.BusinessLayer;
using AssignmentAgiblocks.WebAPI.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentAgiblocks.WebAPI.DI
{
    public static class ServicesDependencyInjection
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>()
                    .AddScoped<IParserFactory, ParserFactory>();
        }
    }
}
