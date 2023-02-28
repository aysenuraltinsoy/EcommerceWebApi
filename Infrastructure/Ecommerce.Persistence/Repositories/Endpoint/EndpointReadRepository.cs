using Ecommerce.Application.Repositories.Endpoint;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Endpoint
{
	public class EndpointReadRepository : ReadRepository<Ecommerce.Domain.Entities.Endpoint>, IEndpointReadRepository
	{
		public EndpointReadRepository(EcommerceDbContext context) : base(context)
		{
		}
	}
}
