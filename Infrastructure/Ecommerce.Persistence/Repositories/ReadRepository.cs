using Ecommerce.Application.Repositories;
using Ecommerce.Domain.Entities.Common;
using Ecommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ecommerce.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EcommerceDbContext _context;

        public ReadRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query=Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return query;       
        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true) 
        { 
            var query=Table.AsQueryable();
            if (!tracking) 
                query= Table.AsNoTracking(); 
                
            return await query.FirstOrDefaultAsync(data=> data.Id== Guid.Parse(id));
        } 

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true) 
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query=Table.AsNoTracking();
           return  await query.FirstOrDefaultAsync(expression); 

        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true) 
        { 
          var query=  Table.Where(expression);
            if (!tracking)
                query = Table.AsNoTracking();
            return query;
        }
    }
}
