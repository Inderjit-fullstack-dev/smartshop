using Microsoft.EntityFrameworkCore;
using Smartshop.Discount.gRPC.Entities;

namespace Smartshop.Discount.gRPC.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
}
