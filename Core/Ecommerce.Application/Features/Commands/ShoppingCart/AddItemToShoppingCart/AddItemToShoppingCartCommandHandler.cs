using Ecommerce.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.ShoppingCart.AddItemToShoppingCart
{
    public class AddItemToShoppingCartCommandHandler : IRequestHandler<AddItemToShoppingCartCommandRequest, AddItemToShoppingCartCommandResponse>
    {
        readonly IShoppingCartService _shoppingCartService;
        public AddItemToShoppingCartCommandHandler(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public async Task<AddItemToShoppingCartCommandResponse> Handle(AddItemToShoppingCartCommandRequest request, CancellationToken cancellationToken)
        {
            await _shoppingCartService.AddItemToShoppingCartAsync(new()
            {
                ProductId= request.ProductId,
                Quantity= request.Quantity
            });
            return new();
        }
    }
}
