using Microsoft.AspNetCore.Mvc;
using Smartshop.Catalog.API.Repositories.Contracts;
using Smartshop.Catalog.API.ViewModels;
using System;
using System.Threading.Tasks;

namespace Smartshop.Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var response = await _productRepository.GetAllProducts();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var response = await _productRepository.GetProductById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            try
            {
                var response = await _productRepository.GetProductByName(name);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            try
            {
                var response = await _productRepository.GetProductsByCategory(category);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel product)
        {
            try
            {
                var result = await _productRepository.CreateProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(string id, ProductViewModel product)
        {
            try
            {
                var result = await _productRepository.UpdateProduct(id, product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                var result = await _productRepository.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
