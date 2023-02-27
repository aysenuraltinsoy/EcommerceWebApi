using Ecommerce.Application.Consts;
using Ecommerce.Application.CustomAttributes;
using Ecommerce.Application.Enums;
using Ecommerce.Application.Features.Commands.Order.CreateOrder;
using Ecommerce.Application.Features.Queries.Order;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.ShoppingCarts, ActionType = Application.Enums.ActionType.Writing, Definition = "Create Order")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
        {
            CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);    
        }

        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = Application.Enums.ActionType.Reading, Definition = "Get All Orders")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
        {
            GetAllOrdersQueryResponse response = await _mediator.Send(getAllOrdersQueryRequest);
            return Ok(response);
        }
    }
}
