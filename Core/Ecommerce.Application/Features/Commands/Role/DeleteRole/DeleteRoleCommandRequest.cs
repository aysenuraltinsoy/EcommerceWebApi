using MediatR;

namespace Ecommerce.Application.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandRequest:IRequest<DeleteRoleCommandResponse>
    {
    
        public string Id { get; set; }
    }
    
}