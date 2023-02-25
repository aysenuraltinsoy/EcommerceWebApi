using Ecommerce.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Queries.ShoppingCart.GetShoppingCartItems
{
    public class GetShoppingCartItemsQueryHandler : IRequestHandler<GetShoppingCartItemsQueryRequest, List<GetShoppingCartItemsQueryResponse>>
    {
        readonly IShoppingCartService _shoppingCartService;
        public GetShoppingCartItemsQueryHandler(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public async Task<List<GetShoppingCartItemsQueryResponse>> Handle(GetShoppingCartItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var shoppingCartItems =await _shoppingCartService.GetAllShoppingCartItemsAsync();

            return shoppingCartItems.Select(si => new GetShoppingCartItemsQueryResponse
            {
                ShoppingCartItemId=si.Id.ToString(),
                Name=si.Product.Name,
                Price=si.Product.Price,
                Description=si.Product.Description,
                Quantity=si.Quantity
            }).ToList();
        }
    }
}
