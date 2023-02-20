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

namespace Ecommerce.Persistence.Services
{
    public class AuthService : IAuthService
    {
       
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password,int accessTokenLifeTime)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            }
            if (user == null)
                throw new NotFoundUserException();


            //for checking Authentication , from identity library
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) //Authentication successful
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                return token;
            }

           throw new Exception();
        }
    }
}
