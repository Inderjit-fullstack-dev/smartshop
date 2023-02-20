using Microsoft.EntityFrameworkCore;
using Smartshop.Discount.API.Entities;

namespace Smartshop.Discount.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
