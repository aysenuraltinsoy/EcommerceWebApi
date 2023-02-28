using MediatR;

namespace Ecommerce.Application.Features.Queries.AutherizationEndpoints.GetRolesToEndpoints
{
	public class GetRolesToEndpointsQueryRequest:IRequest<GetRolesToEndpointsQueryResponse>
	{
		public string Code { get; set; }
		public string Menu { get; set; }
	}
}