using Ecommerce.Application.Features.Commands.Product.CreateProduct;
using Ecommerce.Application.Features.Commands.Product.DeleteProduct;
using Ecommerce.Application.Features.Commands.Product.UpdateProduct;
using Ecommerce.Application.Features.Queries.Product.GetAllProduct;
using Ecommerce.Application.Features.Queries.Product.GetByIdProduct;
using Ecommerce.Application.Repositories;
using Ecommerce.Application.RequestParameters;
using Ecommerce.Application.ViewModels.Products;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
       
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
         
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest) 
        {
            GetAllProductQueryResponse response=  await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response   =await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
          
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response  =await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
           DeleteProductCommandResponse response  = await _mediator.Send(deleteProductCommandRequest);
            return Ok();
        }
    }
}
