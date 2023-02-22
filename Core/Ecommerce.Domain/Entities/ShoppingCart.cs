using Ecommerce.Domain.Entities.Common;
using Ecommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ShoppingCart:BaseEntity
    {
        
        
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public Order Order { get; set; }
        public ICollection<Product> Products { get; set; }
        


        //public Customer Customer { get; set; }
        //public Guid CustomerId { get; set; }


        //public string Description { get; set; }
        //public string Address { get; set; }
        //public long TotalPrice { get; set; }
    }
}
