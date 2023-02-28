using Ecommerce.Application.Repositories.Endpoint;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Endpoint
{
	public class EndpointWriteRepository : WriteRepository<Ecommerce.Domain.Entities.Endpoint>, IEndpointWriteRepository
	{
		public EndpointWriteRepository(EcommerceDbContext context) : base(context)
		{
		}
	}
}
