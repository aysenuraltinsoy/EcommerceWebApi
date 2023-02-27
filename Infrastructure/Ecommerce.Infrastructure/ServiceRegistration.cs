using Ecommerce.Application.Abstractions.Services.Configurations;
using Ecommerce.Application.Abstractions.Token;
using Ecommerce.Infrastructure.Services.Configurations;
using Ecommerce.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
