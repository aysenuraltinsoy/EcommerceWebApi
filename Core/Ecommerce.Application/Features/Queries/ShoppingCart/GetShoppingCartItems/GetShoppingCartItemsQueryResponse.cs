namespace Ecommerce.Application.Features.Queries.ShoppingCart.GetShoppingCartItems
{
    public class GetShoppingCartItemsQueryResponse
    {
        public string ShoppingCartItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}