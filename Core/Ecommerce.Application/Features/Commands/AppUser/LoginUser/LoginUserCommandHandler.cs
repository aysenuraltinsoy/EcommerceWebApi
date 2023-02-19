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

        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> manager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = manager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommanRequest request, CancellationToken cancellationToken)
        {

            Domain.Entities.Identity.AppUser user =await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            }
            if (user == null)
                throw new NotFoundUserException();


            //for checking Authentication , from identity library
            SignInResult result   =await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);  
            if (result.Succeeded) //Authentication successful
            {
              Token token   =   _tokenHandler.CreateAccessToken(5);
                return new()
                {
                    Token=token
                };
            }
                
            return new()
            {
                Message="Invalid Username & Email & Password."
            };
        }
    }
}
