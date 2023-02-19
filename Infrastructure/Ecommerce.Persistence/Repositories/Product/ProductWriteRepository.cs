using Ecommerce.Application.Repositories;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Ecommerce.Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
