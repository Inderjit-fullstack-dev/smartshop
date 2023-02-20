using System.ComponentModel.DataAnnotations;

namespace Smartshop.Discount.API.ViewModels
{
    public class CouponCheckViewModel
    {
        [Required]
        public string CouponCode { get; set; } = string.Empty;
        
        [Required]
        public string ProductName { get; set; } = string.Empty;
    }
}
