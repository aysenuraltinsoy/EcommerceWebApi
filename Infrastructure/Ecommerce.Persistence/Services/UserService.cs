using Ecommerce.Application.Abstractions.Services;
using Ecommerce.Application.DTOs.User;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Commands.AppUser.CreateUser;
using Ecommerce.Domain.Entities.Identity;
using Ecommerce.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        public UserService(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {

            
            Countries selectedCountry = GetCountryFromCode(model.Country);
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                Country = selectedCountry,
            }, model.Password);

            CreateUserResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
            {

                response.Message = "User created.";

            }
            else
                foreach (var error in result.Errors)
                    response.Message += error.Description;

            return response;
        }

        public static Countries GetCountryFromCode(string code)
        {
            if (Enum.TryParse(typeof(Countries), code, out object result))
            {
                return (Countries)result;
            }

            throw new ArgumentException($"Invalid country code: {code}");
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate,int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }
        
    }

}
