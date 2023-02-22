using Ecommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ShoppingCartItem: BaseEntity
    {
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Product Product { get; set; }
    }
}
