using System.ComponentModel.DataAnnotations;

namespace Smartshop.Discount.gRPC.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
