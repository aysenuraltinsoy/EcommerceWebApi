using Ecommerce.Application.Repositories;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IShoppingWriteReadRepository _shoppingWriteReadRepository;
        readonly private IShoppingCartReadRepository _shoppingCartReadRepository;


        readonly private ICategoryWriteRepository _categoryWriteRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IShoppingWriteReadRepository shoppingWriteReadRepository, ICategoryWriteRepository categoryWriteRepository, ICustomerWriteRepository customerWriteRepository, IShoppingCartReadRepository shoppingCartReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _shoppingWriteReadRepository = shoppingWriteReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _shoppingCartReadRepository = shoppingCartReadRepository;
        }
        [HttpGet]
        public async Task Get() 
        {
          ShoppingCart shop=    await _shoppingCartReadRepository.GetByIdAsync("584d992e-7e94-4e05-62a9-08db0c6b7b6d");
            shop.Address = "İst";
            await _shoppingWriteReadRepository.SaveAsync();
        }

       
    }
}
