using Ecommerce.Application.Features.Commands.AutherizationEndpoints.AssignRole;
using Ecommerce.Application.Features.Queries.Role.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AutherizationEndpointsController : ControllerBase
	{
		readonly IMediator _mediator;
		public AutherizationEndpointsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> GetRolesEndpoint(GetRoleByIdQueryRequest getRoleByIdQueryRequest)
		{
			GetRoleByIdQueryResponse response = await _mediator.Send(getRoleByIdQueryRequest);
			return Ok(response);
		}
		[HttpPost]
		public async Task<IActionResult> AssignRoleEndPoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
		{
			assignRoleEndpointCommandRequest.Type = typeof(Program);
			AssignRoleEndpointCommandResponse response = await _mediator.Send(assignRoleEndpointCommandRequest);
			return Ok(response);
		}
	}
}
