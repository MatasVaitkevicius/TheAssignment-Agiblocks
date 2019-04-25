using AssignmentAgiblocks.DI;
using AssignmentAgiblocks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentAgiblocks_xUnit_Tests
{
    public class ServiceProviderTest
    {
        public ServiceProviderTest()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<RepositoryContext>(opt => opt.UseInMemoryDatabase());

            serviceProvider.AddRepositoryDependencies();
            serviceProvider.AddServicesDependencies();

            ServiceProvider = serviceProvider.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
