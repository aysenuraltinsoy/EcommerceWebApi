using Ecommerce.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.AutherizationEndpoints.AssignRole
{
	public class AssignRoleEndpointCommandHandler : IRequestHandler<AssignRoleEndpointCommandRequest, AssignRoleEndpointCommandResponse>
	{
		readonly IAuthorizationEndPointService _authorizationEndPointService;
		public AssignRoleEndpointCommandHandler(IAuthorizationEndPointService authorizationEndPointService)
		{
			_authorizationEndPointService = authorizationEndPointService;
		}
		public async Task<AssignRoleEndpointCommandResponse> Handle(AssignRoleEndpointCommandRequest request, CancellationToken cancellationToken)
		{
			await _authorizationEndPointService.AssignRoleEndpointAsync(request.Roles, request.Menu, request.Code, request.Type);
			return new()
			{

			};
		}
	}
}
