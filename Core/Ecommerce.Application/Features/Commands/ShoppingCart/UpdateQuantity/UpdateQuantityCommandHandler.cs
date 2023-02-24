using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.ShoppingCart.UpdateQuantity
{
    public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
    {
        public Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
