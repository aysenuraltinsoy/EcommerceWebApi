using Ecommerce.Application.Repositories;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<Ecommerce.Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(EcommerceDbContext context) : base(context)
        {
        }
    }
}
