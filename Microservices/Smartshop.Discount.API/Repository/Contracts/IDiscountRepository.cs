using Smartshop.Discount.API.Entities;
using Smartshop.Discount.API.ViewModels;

namespace Smartshop.Discount.API.Repository.Contracts
{
    public interface IDiscountRepository
    {
        Task<List<Coupon>> GetAllCoupons();
        Task<Coupon> AddCoupon(Coupon coupon);
        Task<Coupon?> GetCouponById(long id);
        Task<Coupon> UpdateCoupon(long id, Coupon coupon);
        Task<Coupon> DeleteCoupon(long id);
        Task<bool> IsValidCoupon(CouponCheckViewModel request);
    }
}
