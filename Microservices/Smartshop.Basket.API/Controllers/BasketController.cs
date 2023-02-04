using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smartshop.Basket.API.Entities;
using Smartshop.Basket.API.Repositories;

namespace Smartshop.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasket _basket;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasket basket, ILogger<BasketController> logger)
        {
            _basket = basket;
            _logger = logger;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetCart(string username)
        {
            try
            {
                var result = await _basket.GetCart(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateCart(string username, ShoppingCart cart)
        {
            try
            {
                var result = await _basket.UpdateCart(username, cart);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> ClearCart(string username)
        {
            try
            {
                var result = await _basket.ClearCart(username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
