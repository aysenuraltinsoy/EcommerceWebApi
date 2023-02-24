using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.ShoppingCart.DeleteShoppingCartItem
{
    public class DeleteShoppingCartItemCommandHandler : IRequestHandler<DeleteShoppingCartItemCommandRequest, DeleteShoppingCartItemCommandResponse>
    {
        public Task<DeleteShoppingCartItemCommandResponse> Handle(DeleteShoppingCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
