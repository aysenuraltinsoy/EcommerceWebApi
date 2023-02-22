using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order:BaseEntity
    {
        //public Guid CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string OrderCode { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
        //public ICollection<Product> Products { get; set; }
        //public Customer Customer { get; set; }
        public CompletedOrder CompletedOrder { get; set; }

    }
}
