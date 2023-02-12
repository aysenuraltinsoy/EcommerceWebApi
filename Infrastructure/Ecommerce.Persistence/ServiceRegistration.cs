using Ecommerce.Application.Repositories;
using Ecommerce.Persistence.Context;
using Ecommerce.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)  
        {

            services.AddDbContext<EcommerceDbContext>(_ => _.UseSqlServer(Configuration.ConnectionString)); //Dbcontext default: Scoped
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IShoppingCartReadRepository,ShoppingCartReadRepository>();
            services.AddScoped<IShoppingWriteReadRepository,ShoppingCartWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
            services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository,CategoryWriteRepository>();
        }
    }
}
