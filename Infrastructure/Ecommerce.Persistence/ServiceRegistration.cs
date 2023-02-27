using Ecommerce.Application.Abstractions.Services;
using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repositories.Order;
using Ecommerce.Application.Repositories.ShoppingCartItem;
using Ecommerce.Domain.Entities.Identity;
using Ecommerce.Persistence.Context;
using Ecommerce.Persistence.Repositories;
using Ecommerce.Persistence.Repositories.Category;
using Ecommerce.Persistence.Repositories.Customer;
using Ecommerce.Persistence.Repositories.Order;
using Ecommerce.Persistence.Repositories.Product;
using Ecommerce.Persistence.Repositories.ShoppingCart;
using Ecommerce.Persistence.Repositories.ShoppingCartItem;
using Ecommerce.Persistence.Services;
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
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
               
            }).AddEntityFrameworkStores<EcommerceDbContext>();

            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IShoppingCartReadRepository,ShoppingCartReadRepository>();
            services.AddScoped<IShoppingCartWriteRepository, ShoppingCartWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
            services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository,CategoryWriteRepository>();
            services.AddScoped<IOrderReadRepository,OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
            
            services.AddScoped<IShoppingCartItemReadRepository,ShoppingCartItemReadRepository>();
            services.AddScoped<IShoppingCartItemWriteRepository, ShoppingCartItemWriteRepository>();



            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IShoppingCartService,ShoppingCartService>(); 
            services.AddScoped<IOrderService,OrderService>(); 
        }
    }
}
