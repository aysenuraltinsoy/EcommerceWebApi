using Ecommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.AppUser.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public Token   Token { get; set; }
    }
}
