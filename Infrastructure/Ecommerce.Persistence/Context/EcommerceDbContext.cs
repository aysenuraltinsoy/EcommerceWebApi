using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Common;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Context
{
    public class EcommerceDbContext:IdentityDbContext<AppUser,AppRole,string>
    {

        public EcommerceDbContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        // public DbSet<CompletedOrder> CompletedOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasKey(b => b.Id);
            builder.Entity<ShoppingCart>().HasOne(b => b.Order)
                .WithOne(o => o.ShoppingCart).HasForeignKey<Order>(b => b.Id);

            builder.Entity<Order>()
                .HasIndex(o => o.OrderCode)
                .IsUnique();
        //In cases where we use the Identity library, the following piece of code should be included in this method.
            base.OnModelCreating(builder);
        }


        //Interceptor
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //It enables the capture of changes made or newly added data over entities
           var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added=>data.Entity.CreatedDate=DateTime.Now,
                    EntityState.Modified=>data.Entity.UpdatedDate=DateTime.Now,
                    _=>DateTime.Now
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
