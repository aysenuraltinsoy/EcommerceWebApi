using Ecommerce.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly IShoppingCartService _shoppingCartService;
        public CreateOrderCommandHandler(IOrderService orderService, IShoppingCartService shoppingCartService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            _orderService.CreateOrder(new()
            {
                Address = request.Address,
                Description = request.Description,
                ShoppingCartId = _shoppingCartService.GetUserActiveShoppingCart?.Id.ToString()
            });

            return new();
        }
    }
}
