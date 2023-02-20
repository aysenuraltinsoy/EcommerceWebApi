using Ecommerce.Application.Abstractions.Services;
using Ecommerce.Application.DTOs.User;
using Ecommerce.Application.Exceptions;
using Ecommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {

        readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

             CreateUserResponse  response=await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Country = request.Country,
                Password = request.Password,
                PasswordAgain = request.PasswordAgain,
                Username = request.Username
            });
            

            return new()
            { Message= response.Message,
            Succeeded=response.Succeeded
            };
            
        }

        
    }

}
