using Ecommerce.Application.Repositories;

using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.ShoppingCart
{
    public class ShoppingCartReadRepository : ReadRepository<Ecommerce.Domain.Entities.ShoppingCart>, IShoppingCartReadRepository
    {
        public ShoppingCartReadRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
