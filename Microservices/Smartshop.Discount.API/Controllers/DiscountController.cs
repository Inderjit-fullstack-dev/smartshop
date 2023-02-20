using Microsoft.AspNetCore.Mvc;
using Smartshop.Discount.API.Entities;
using Smartshop.Discount.API.Repository.Contracts;
using Smartshop.Discount.API.ViewModels;

namespace Smartshop.Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(IDiscountRepository discountRepository, ILogger<DiscountController> logger)
        {
            _discountRepository = discountRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoupons()
        {
            try
            {
                var response = await _discountRepository.GetAllCoupons();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(long id)
        {
            try
            {
                var response = await _discountRepository.GetCouponById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCoupon(Coupon coupon)
        {
            try
            {
                var response = await _discountRepository.AddCoupon(coupon);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoupon(long id, Coupon coupon)
        {
            try
            {
                var response = await _discountRepository.UpdateCoupon(id, coupon);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(long id)
        {
            try
            {
                var response = await _discountRepository.DeleteCoupon(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> IsValidCoupon(CouponCheckViewModel request)
        {
            try
            {
                var response = await _discountRepository.IsValidCoupon(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
