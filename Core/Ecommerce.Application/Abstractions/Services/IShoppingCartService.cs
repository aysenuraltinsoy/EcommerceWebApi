using Ecommerce.Application.ViewModels.ShoppingCart;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Abstractions.Services
{
    public interface IShoppingCartService
    {
        public Task<List<ShoppingCartItem>> GetAllShoppingCartItemsAsync();
        public Task AddItemToShoppingCartAsync(CreateShoppingCartItemVM shoppingCartItem);
        public Task UpdateQuantityAsync(UpdateShoppingCartItemVM shoppingCartItem);
        public Task DeleteItemAsync(string shoppingCartItemId);
    }
}
