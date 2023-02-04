using Smartshop.Basket.API.Entities;

namespace Smartshop.Basket.API.Repositories
{
    public interface IBasket
    {
        Task<ShoppingCart?> GetCart(string username);
        Task<ShoppingCart?> UpdateCart(string username, ShoppingCart cart);
        Task<bool> ClearCart(string username);
    }
}
