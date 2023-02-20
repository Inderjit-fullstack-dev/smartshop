using System.ComponentModel.DataAnnotations;

namespace Smartshop.Discount.gRPC.Entities
{
    public class Coupon : BaseEntity
    {
        [Required]
        public string CouponCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public string ProductName { get; set; } = string.Empty;
        
        [Required]
        public int Amount { get; set; }
    }
}
