﻿using Ecommerce.Domain.Entities.Common;
using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string Username { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        //public Countries Country { get; set; }
        //public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
