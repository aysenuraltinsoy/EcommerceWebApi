using Ecommerce.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Queries.AutherizationEndpoints.GetRolesToEndpoints
{
	public class GetRolesToEndpointsQueryHandler : IRequestHandler<GetRolesToEndpointsQueryRequest, GetRolesToEndpointsQueryResponse>
	{
		readonly IAuthorizationEndPointService _authorizationEndPointService;
		public GetRolesToEndpointsQueryHandler(IAuthorizationEndPointService authorizationEndPointService)
		{
			_authorizationEndPointService = authorizationEndPointService;
		}
		public async Task<GetRolesToEndpointsQueryResponse> Handle(GetRolesToEndpointsQueryRequest request, CancellationToken cancellationToken)
		{
			var datas = await _authorizationEndPointService.GetRolesToEndpointAsync(request.Code,request.Menu);
			return new()
			{
				Roles = datas
			};
		}
	}
}
