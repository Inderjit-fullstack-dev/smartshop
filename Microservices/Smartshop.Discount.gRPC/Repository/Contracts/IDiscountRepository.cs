using Smartshop.Discount.gRPC.Entities;
using Smartshop.Discount.gRPC.ViewModels;

namespace Smartshop.Discount.gRPC.Repository.Contracts
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
