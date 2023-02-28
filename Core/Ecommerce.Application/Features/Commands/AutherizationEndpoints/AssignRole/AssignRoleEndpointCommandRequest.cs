using MediatR;
using System.Reflection.PortableExecutable;

namespace Ecommerce.Application.Features.Commands.AutherizationEndpoints.AssignRole
{
	public class AssignRoleEndpointCommandRequest:IRequest<AssignRoleEndpointCommandResponse>
	{
		public string[] Roles { get; set; }
		public string Code { get; set; }
		public string Menu { get; set; }

		public Type? Type { get; set; }
	}
}