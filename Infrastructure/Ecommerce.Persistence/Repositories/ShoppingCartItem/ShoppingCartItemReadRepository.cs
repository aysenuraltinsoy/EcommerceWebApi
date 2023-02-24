using Ecommerce.Application.Repositories.ShoppingCartItem;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.ShoppingCartItem
{
    public class ShoppingCartItemReadRepository : ReadRepository<Ecommerce.Domain.Entities.ShoppingCartItem>, IShoppingCartItemReadRepository
    {
        public ShoppingCartItemReadRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
