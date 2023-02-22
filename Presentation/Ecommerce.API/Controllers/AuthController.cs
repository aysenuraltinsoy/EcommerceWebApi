using Ecommerce.Application.Features.Commands.AppUser.LoginUser;
using Ecommerce.Application.Features.Commands.AppUser.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommanRequest loginUserCommanRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommanRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        //if we get the parameter with fromquery it fixes the token to be compatible with http protocols, the correct value is not coming
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenCommandRequest refreshTokenCommandRequest) 
            
        {
            RefreshTokenCommandResponse response = await _mediator.Send(refreshTokenCommandRequest);
            return Ok(response);
        }
    }
}
