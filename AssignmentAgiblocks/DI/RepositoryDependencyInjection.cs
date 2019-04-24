using AssignmentAgiblocks.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentAgiblocks.DI
{
    public static class RepositoryDependencyInjection
    {
        public static void AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
