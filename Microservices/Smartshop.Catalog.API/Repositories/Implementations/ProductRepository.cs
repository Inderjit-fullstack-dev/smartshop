using AutoMapper;
using MongoDB.Driver;
using Smartshop.Catalog.API.Data;
using Smartshop.Catalog.API.Entities;
using Smartshop.Catalog.API.Repositories.Contracts;
using Smartshop.Catalog.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartshop.Catalog.API.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(IApplicationContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _mapper = mapper;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _context.Products.Find(p => p.ProductName.ToUpper() == name.ToUpper())
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName)
        {
            return await _context.Products.Find(p => p.Category.ToUpper() == categoryName.ToUpper())
                        .ToListAsync();
        }

        public async Task<Product> CreateProduct(ProductViewModel product)
        {
            var mappedProduct = _mapper.Map<Product>(product);
            await _context.Products.InsertOneAsync(mappedProduct);
            return mappedProduct;
        }

        public async Task<Product> UpdateProduct(string id, ProductViewModel product)
        {
            var mappedProduct = _mapper.Map<Product>(product);
            await _context.Products.ReplaceOneAsync(x => x.Id == id, mappedProduct);
            return mappedProduct;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            await _context.Products.DeleteOneAsync(x => x.Id == id);
            return true;
        }
    }
}
