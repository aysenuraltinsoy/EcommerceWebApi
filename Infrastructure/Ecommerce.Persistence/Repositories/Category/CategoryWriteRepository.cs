using Ecommerce.Application.Repositories;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Ecommerce.Domain.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
