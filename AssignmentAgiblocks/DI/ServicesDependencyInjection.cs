using AssignmentAgiblocks.BusinessLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAgiblocks.DI
{
    public static class ServicesDependencyInjection
    {
        public static void AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
