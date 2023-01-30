using Smartshop.Catalog.API.Entities;
using Smartshop.Catalog.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartshop.Catalog.API.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetProductsByCategory(string categoryName);
        Task<Product> GetProductById(string id);
        Task<Product> GetProductByName(string name);
        Task<Product> CreateProduct(ProductViewModel product);
        Task<Product> UpdateProduct(string id, ProductViewModel product);
        Task<bool> DeleteProduct(string id);
    }
}
