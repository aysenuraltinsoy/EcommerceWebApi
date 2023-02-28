using Ecommerce.Application.Repositories.Endpoint;
using Ecommerce.Application.Repositories.Menu;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Menu
{
	public class MenuWriteRepository : WriteRepository<Ecommerce.Domain.Entities.Menu>, IMenuWriteRepository
	{
		public MenuWriteRepository(EcommerceDbContext context) : base(context)
		{
		}
	}
}
