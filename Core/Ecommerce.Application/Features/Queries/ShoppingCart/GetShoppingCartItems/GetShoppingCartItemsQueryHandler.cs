using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Queries.ShoppingCart.GetShoppingCartItems
{
    public class GetShoppingCartItemsQueryHandler : IRequestHandler<GetShoppingCartItemsQueryRequest, GetShoppingCartItemsQueryResponse>
    {
        public Task<GetShoppingCartItemsQueryResponse> Handle(GetShoppingCartItemsQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
