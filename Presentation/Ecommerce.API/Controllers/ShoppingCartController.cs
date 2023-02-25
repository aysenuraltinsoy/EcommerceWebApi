using Ecommerce.Application.Features.Commands.ShoppingCart.AddItemToShoppingCart;
using Ecommerce.Application.Features.Commands.ShoppingCart.DeleteShoppingCartItem;
using Ecommerce.Application.Features.Commands.ShoppingCart.UpdateQuantity;
using Ecommerce.Application.Features.Queries.ShoppingCart.GetShoppingCartItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ShoppingCartController : ControllerBase
    {
        readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingCartItems([FromQuery] GetShoppingCartItemsQueryRequest getShoppingCartItemsQueryRequest)
        {
            List<GetShoppingCartItemsQueryResponse> response = await _mediator.Send(getShoppingCartItemsQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToShoppingCart(AddItemToShoppingCartCommandRequest addItemToShoppingCartCommandRequest)
        {
            AddItemToShoppingCartCommandResponse response = await _mediator.Send(addItemToShoppingCartCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(response);
        }
        [HttpDelete ("{ShoppingCartItemId}")]
        public async Task<IActionResult> DeleteShoppingCartItem([FromRoute] DeleteShoppingCartItemCommandRequest deleteShoppingCartItemCommandRequest)
        {
            DeleteShoppingCartItemCommandResponse response = await _mediator.Send(deleteShoppingCartItemCommandRequest);
            return Ok(response);
        }
    }
}
