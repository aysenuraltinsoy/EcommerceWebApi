using Ecommerce.Application.Consts;
using Ecommerce.Application.CustomAttributes;
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
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingCarts,ActionType = Application.Enums.ActionType.Reading,Definition ="Get Shopping Cart Items")]
        public async Task<IActionResult> GetShoppingCartItems([FromQuery] GetShoppingCartItemsQueryRequest getShoppingCartItemsQueryRequest)
        {
            List<GetShoppingCartItemsQueryResponse> response = await _mediator.Send(getShoppingCartItemsQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingCarts, ActionType = Application.Enums.ActionType.Writing, Definition = "Add Item to Shopping Cart")]
        public async Task<IActionResult> AddItemToShoppingCart(AddItemToShoppingCartCommandRequest addItemToShoppingCartCommandRequest)
        {
            AddItemToShoppingCartCommandResponse response = await _mediator.Send(addItemToShoppingCartCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingCarts, ActionType = Application.Enums.ActionType.Updating, Definition = "Update Quantity")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        {
            UpdateQuantityCommandResponse response = await _mediator.Send(updateQuantityCommandRequest);
            return Ok(response);
        }
        [HttpDelete ("{ShoppingCartItemId}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingCarts, ActionType = Application.Enums.ActionType.Deleting, Definition = "Remove Shopping Cart Item")]
        public async Task<IActionResult> DeleteShoppingCartItem([FromRoute] DeleteShoppingCartItemCommandRequest deleteShoppingCartItemCommandRequest)
        {
            DeleteShoppingCartItemCommandResponse response = await _mediator.Send(deleteShoppingCartItemCommandRequest);
            return Ok(response);
        }
    }
}
