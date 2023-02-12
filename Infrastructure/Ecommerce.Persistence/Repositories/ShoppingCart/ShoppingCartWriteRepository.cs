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
    public class ShoppingCartWriteRepository : WriteRepository<ShoppingCart>, IShoppingWriteReadRepository
    {
        public ShoppingCartWriteRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
