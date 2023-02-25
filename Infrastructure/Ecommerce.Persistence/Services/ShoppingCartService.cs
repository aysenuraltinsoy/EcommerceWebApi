using Ecommerce.Application.Abstractions.Services;
using Ecommerce.Application.Repositories;
using Ecommerce.Application.Repositories.Order;
using Ecommerce.Application.Repositories.ShoppingCartItem;
using Ecommerce.Application.ViewModels.ShoppingCart;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Persistence.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IShoppingCartWriteRepository _shoppingCartWriteRepository;
        readonly IShoppingCartReadRepository _shoppingCartReadRepository;
        readonly IShoppingCartItemWriteRepository _shoppingCartItemWriteRepository;
        readonly IShoppingCartItemReadRepository _shoppingCartItemReadRepository;
        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository, IShoppingCartWriteRepository shoppingCartWriteRepository, IShoppingCartItemWriteRepository shoppingCartItemWriteRepository, IShoppingCartItemReadRepository shoppingCartItemReadRepository, IShoppingCartReadRepository shoppingCartReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _shoppingCartWriteRepository = shoppingCartWriteRepository;
            _shoppingCartItemWriteRepository = shoppingCartItemWriteRepository;
            _shoppingCartItemReadRepository = shoppingCartItemReadRepository;
            _shoppingCartReadRepository = shoppingCartReadRepository;
        }

        private async Task<ShoppingCart?> ContextUser()
        {
            var session = _httpContextAccessor.HttpContext;
            var username = _httpContextAccessor?.HttpContext?.User.Identity?.Name;
            var deneme = _httpContextAccessor.HttpContext.User.Claims;
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users.Include(u => u.ShoppingCarts).FirstOrDefaultAsync(u => u.UserName == username);
                var sCart = from shoppingcart in user.ShoppingCarts
                           join order in _orderReadRepository.Table on shoppingcart.Id equals order.Id into ShoppingCartOrder
                           from o in ShoppingCartOrder.DefaultIfEmpty()
                           select new
                           {
                               ShoppingCart=shoppingcart,
                               Order=o
                           };
                ShoppingCart? targetShoppingCart = null;
                if (sCart.Any(x=>x.Order is null))
                {
                    targetShoppingCart = sCart.FirstOrDefault(x => x.Order is null)?.ShoppingCart;
                }
                else
                {
                    targetShoppingCart = new();
                    user.ShoppingCarts.Add(targetShoppingCart);
                }
                await _shoppingCartWriteRepository.SaveAsync();
                return targetShoppingCart;
            }
            throw new Exception("unexpected error");

        }
        public async Task AddItemToShoppingCartAsync(CreateShoppingCartItemVM shoppingCartItem)
        {
            ShoppingCart? shoppingCart = await ContextUser();
            if (shoppingCart!= null)
            {
               ShoppingCartItem _shoppingCartItem = await _shoppingCartItemReadRepository.GetSingleAsync(si=>si.ShoppingCartId==shoppingCart.Id && si.ProductId==Guid.Parse(shoppingCartItem.ProductId));
                if (_shoppingCartItem!=null)
                {
                    _shoppingCartItem.Quantity++;
                }
                else
                {
                    await _shoppingCartItemWriteRepository.AddAsync(new()
                    {
                        ShoppingCartId=shoppingCart.Id,
                        ProductId=Guid.Parse(shoppingCartItem.ProductId),
                        Quantity=shoppingCartItem.Quantity
                    });

                    
                }
                await _shoppingCartItemWriteRepository.SaveAsync();
            }
        }

        public async Task DeleteItemAsync(string shoppingCartItemId)
        {
            ShoppingCartItem? shoppingCartItem = await _shoppingCartItemReadRepository.GetByIdAsync(shoppingCartItemId);
            if (shoppingCartItem!=null)
            {
                _shoppingCartItemWriteRepository.Remove(shoppingCartItem);
                await _shoppingCartItemWriteRepository.SaveAsync();
            }
        }

        public async Task<List<ShoppingCartItem>> GetAllShoppingCartItemsAsync()
        {
            ShoppingCart? shoppingCart = await ContextUser();
            ShoppingCart? result = await _shoppingCartReadRepository.Table.Include(s => s.ShoppingCartItems).ThenInclude(si => si.Product).FirstOrDefaultAsync(s => s.Id == shoppingCart.Id);


            return result.ShoppingCartItems.ToList();
        }

        public async Task UpdateQuantityAsync(UpdateShoppingCartItemVM shoppingCartItem)
        {
            ShoppingCartItem? updatedShoppingCartItem = await _shoppingCartItemReadRepository.GetByIdAsync(shoppingCartItem.ShoppingCartItemId);
            if (updatedShoppingCartItem != null)
            {
                updatedShoppingCartItem.Quantity = shoppingCartItem.Quantity;
               await _shoppingCartItemWriteRepository.SaveAsync();
            }
        }
    }
}
