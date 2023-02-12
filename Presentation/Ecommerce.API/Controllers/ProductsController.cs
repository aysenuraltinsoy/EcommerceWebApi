﻿using Ecommerce.Application.Repositories;
using Ecommerce.Application.RequestParameters;
using Ecommerce.Application.ViewModels.Products;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
       
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination) 
        {
            var totalCount=_productReadRepository.GetAll(false).Count();
            var products=_productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Price,
                p.Stock,
                p.CreatedDate,
                p.UpdatedDate
            });
            return Ok(new
            {
                totalCount, 
                products
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductVM model)
        {
            
            await _productWriteRepository.AddAsync(new()
            {
                Name=model.Name,
                Description=model.Description,
                Price=model.Price,
                Stock=model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductVM model)
        {
            Product product=await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock= model.Stock;
            product.Price= model.Price;
            product.Name= model.Name;
            product.Description= model.Description;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
