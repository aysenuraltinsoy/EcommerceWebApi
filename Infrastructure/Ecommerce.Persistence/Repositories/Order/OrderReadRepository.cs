using Ecommerce.Application.Repositories.Order;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Ecommerce.Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
