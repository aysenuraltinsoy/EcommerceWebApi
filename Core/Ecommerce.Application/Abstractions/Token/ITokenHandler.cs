﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute);
    }
}