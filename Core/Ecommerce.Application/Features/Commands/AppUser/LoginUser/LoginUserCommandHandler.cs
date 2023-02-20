using Ecommerce.Application.Abstractions.Services;
using Ecommerce.Application.Abstractions.Token;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommanRequest, LoginUserCommandResponse>
    {

        readonly IAuthService _authService;
        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommanRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password,15);
            return new()
            {
                Token = token
            };
           
        }
    }
}
