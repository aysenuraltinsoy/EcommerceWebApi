using Ecommerce.Application.Repositories;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.ShoppingCart
{
    public class ShoppingCartWriteRepository : WriteRepository<Ecommerce.Domain.Entities.ShoppingCart>, IShoppingWriteReadRepository
    {
        public ShoppingCartWriteRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
