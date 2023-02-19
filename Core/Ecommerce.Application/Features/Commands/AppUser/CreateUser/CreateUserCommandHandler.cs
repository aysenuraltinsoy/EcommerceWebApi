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

        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {


            Countries selectedCountry = GetCountryFromCode(request.Country);
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id=Guid.NewGuid().ToString(),
                UserName = request.Username,
                Email = request.Email,
                Country = selectedCountry,
            }, request.Password);

            CreateUserCommandResponse response=new() { Succeeded=result.Succeeded};
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
    }

}
