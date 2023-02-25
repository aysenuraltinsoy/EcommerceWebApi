using MediatR;

namespace Ecommerce.Application.Features.Queries.ShoppingCart.GetShoppingCartItems
{
    public class GetShoppingCartItemsQueryRequest:IRequest<List<GetShoppingCartItemsQueryResponse>>
    {
    }
}