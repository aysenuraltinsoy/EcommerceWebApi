using Ecommerce.Application.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    public class ShoppingCartReadRepository : ReadRepository<ShoppingCart>, IShoppingCartReadRepository
    {
        public ShoppingCartReadRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
