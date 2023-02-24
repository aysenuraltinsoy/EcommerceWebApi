using Ecommerce.Application.Repositories.ShoppingCartItem;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.ShoppingCartItem
{
    public class ShoppingCartItemWriteRepository : WriteRepository<Ecommerce.Domain.Entities.ShoppingCartItem>, IShoppingCartItemWriteRepository
    {
        public ShoppingCartItemWriteRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
