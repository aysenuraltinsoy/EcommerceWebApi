using Ecommerce.Application.Abstractions.Services;
using Ecommerce.Application.DTOs.Order;
using Ecommerce.Application.Repositories.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        public async Task CreateOrder(CreateOrder createOrder)
        {
            var orderCode = (new Random().NextDouble() * 10000).ToString(); 
            orderCode.Substring( orderCode.IndexOf(".")+1,orderCode.Length-orderCode.IndexOf(".")-1);
            await _orderWriteRepository.AddAsync(new()
            {
                Address = createOrder.Address,
                Id = Guid.Parse(createOrder.ShoppingCartId),
                Description = createOrder.Description,
                OrderCode= orderCode
            });
            await _orderWriteRepository.SaveAsync();
        }

        public async Task<ListOrder> GetAllOrdersAsync(int page, int size)
        {
           var query= _orderReadRepository.Table.Include(o => o.ShoppingCart).ThenInclude(u => u.User).Include(o => o.ShoppingCart).ThenInclude(s => s.ShoppingCartItems).ThenInclude(si => si.Product);
                
            var data= query.Skip(page*size).Take(size);

            return new()
            {
                TotalOrderCount = await query.CountAsync(),
                Orders = await data.Select(o=> new 
                {
                    CreatedDate=o.CreatedDate,
                    OrderCode=o.OrderCode,
                    TotalPrice=o.ShoppingCart.ShoppingCartItems.Sum(si=>si.Product.Price*si.Quantity),
                    UserName=o.ShoppingCart.User.UserName
                }).ToListAsync()
            };
        }
    }
}
