using MediatR;

namespace Ecommerce.Application.Features.Commands.ShoppingCart.DeleteShoppingCartItem
{
    public class DeleteShoppingCartItemCommandRequest:IRequest<DeleteShoppingCartItemCommandResponse>
    {
        public string ShoppingCartItemId { get; set; }
    }
}