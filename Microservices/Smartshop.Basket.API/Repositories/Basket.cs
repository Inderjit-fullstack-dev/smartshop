using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Smartshop.Basket.API.Entities;

namespace Smartshop.Basket.API.Repositories
{
    public class Basket : IBasket
    {
        private readonly IDistributedCache _redisCache;

        public Basket(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<ShoppingCart?> GetCart(string username)
        {
            var basketData = await _redisCache.GetStringAsync(username);
            if (string.IsNullOrEmpty(basketData))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basketData);
        }

        public async Task<ShoppingCart?> UpdateCart(string username, ShoppingCart cart)
        {
            var serialisedBasketData = JsonConvert.SerializeObject(cart);
            await _redisCache.SetStringAsync(username, serialisedBasketData);

            return await GetCart(username);
        }

        public async Task<bool> ClearCart(string username)
        {
            await _redisCache.RemoveAsync(username);
            return true;
        }
    }
}
