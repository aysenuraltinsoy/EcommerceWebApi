using MediatR;

namespace Ecommerce.Application.Features.Commands.ShoppingCart.UpdateQuantity
{
    public class UpdateQuantityCommandRequest:IRequest<UpdateQuantityCommandResponse>
    {
        public string ShoppingCartItemId { get; set; }
        public int Quantity { get; set; }
    }
}