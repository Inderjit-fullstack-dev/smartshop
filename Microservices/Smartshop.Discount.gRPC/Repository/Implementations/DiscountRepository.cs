using Microsoft.EntityFrameworkCore;
using Smartshop.Discount.gRPC.Data;
using Smartshop.Discount.gRPC.Entities;
using Smartshop.Discount.gRPC.Repository.Contracts;
using Smartshop.Discount.gRPC.ViewModels;

namespace Smartshop.Discount.API.Repository.Implementations
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDBContext _context;

        public DiscountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Coupon>> GetAllCoupons()
        {
            return await _context.Coupons.ToListAsync();
        }

        public async Task<Coupon?> GetCouponById(long id)
        {
            return await _context.Coupons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;

        }

        public async Task<Coupon> UpdateCoupon(long id, Coupon coupon)
        {
            var couponInDB = await GetCouponById(id);
            if (couponInDB == null)
                throw new Exception("No Data Found!");

            couponInDB.ProductName = coupon.ProductName;
            couponInDB.CouponCode = coupon.CouponCode;
            couponInDB.Description = coupon.Description;
            couponInDB.Amount = coupon.Amount;

            await _context.SaveChangesAsync();
            return couponInDB;
        }

        public async Task<Coupon> DeleteCoupon(long id)
        {
            var couponInDB = await GetCouponById(id);
            if (couponInDB == null)
                throw new Exception("No Data Found!");

            _context.Coupons.Remove(couponInDB);
            await _context.SaveChangesAsync();

            return couponInDB;
        }

        public async Task<bool> IsValidCoupon(CouponCheckViewModel request)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponCode == request.CouponCode &&
                x.ProductName.ToLower() == request.ProductName.ToLower());

            if (coupon != null)
                return true;

            return false;
        }
    }
}
