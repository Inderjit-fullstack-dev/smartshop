using System.ComponentModel.DataAnnotations;

namespace Smartshop.Catalog.API.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public string ProductName { get; set; }
        
        [Required]
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        
        [Required]
        public decimal Price { get; set; }
    }
}
