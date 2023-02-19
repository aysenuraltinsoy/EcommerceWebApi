using Ecommerce.Application.Repositories;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Ecommerce.Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
