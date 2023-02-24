using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.ViewModels.ShoppingCart
{
    public class UpdateShoppingCartItemVM
    {
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }   
    }
}
