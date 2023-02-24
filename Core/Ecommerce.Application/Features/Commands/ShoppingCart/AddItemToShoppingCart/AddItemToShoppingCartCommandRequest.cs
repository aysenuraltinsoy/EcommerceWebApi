using MediatR;

namespace Ecommerce.Application.Features.Commands.ShoppingCart.AddItemToShoppingCart
{
    public class AddItemToShoppingCartCommandRequest:IRequest<AddItemToShoppingCartCommandResponse>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}