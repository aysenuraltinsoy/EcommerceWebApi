using Ecommerce.Application.Abstractions.Services;
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
        readonly IShoppingCartService _shoppingCartService;

        public DeleteShoppingCartItemCommandHandler(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public async Task<DeleteShoppingCartItemCommandResponse> Handle(DeleteShoppingCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _shoppingCartService.DeleteItemAsync(request.ShoppingCartItemId);
                return new();
        }
    }
}
