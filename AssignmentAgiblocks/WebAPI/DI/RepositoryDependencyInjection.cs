using AssignmentAgiblocks.WebAPI.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentAgiblocks.WebAPI.DI
{
    public static class RepositoryDependencyInjection
    {
        public static void AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
