using Ecommerce.Application.Repositories.Menu;
using Ecommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Repositories.Menu
{
	public class MenuReadRepository : ReadRepository<Ecommerce.Domain.Entities.Menu>, IMenuReadRepository
	{
		public MenuReadRepository(EcommerceDbContext context) : base(context)
		{
		}
	}
}
