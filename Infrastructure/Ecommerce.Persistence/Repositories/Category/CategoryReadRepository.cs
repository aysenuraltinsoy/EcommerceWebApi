using Ecommerce.Application.Repositories;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Ecommerce.Domain.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
