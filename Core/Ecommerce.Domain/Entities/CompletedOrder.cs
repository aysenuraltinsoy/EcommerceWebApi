﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class CompletedOrder
    {

        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}
