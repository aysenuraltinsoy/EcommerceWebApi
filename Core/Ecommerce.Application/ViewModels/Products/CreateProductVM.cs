using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.ViewModels.Products
{
    public class CreateProductVM
    {
        public string Name { get; set; }      
        public string Description { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}
