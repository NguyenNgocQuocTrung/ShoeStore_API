using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.Params;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseController
    {
        public IProductRepository _productRepository { get; set; }

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        //write code to sorting product by descending order of price
        [HttpGet("data")]
        public async Task<IActionResult> GetProducts(string sortBy)
        {
            
            var data = await _productRepository.GetProductsAsync(sortBy);
            return Ok(data);
        }

        [HttpGet("data/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var data = await _productRepository.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var data = await _productRepository.AddAsync(product);
            return Ok(data);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var getProduct = await _productRepository.GetByIdAsync(product.Id);
            if (getProduct == null)
            {
                return NotFound();
            }
            await _productRepository.UpdateAsync(product);
            return Ok(product);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var getProduct = await _productRepository.GetByIdAsync(id);
            if (getProduct == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(getProduct);
            return Ok();
        }
        

      [HttpGet("page")]
public async Task<IActionResult> GetPaging([FromQuery] ProductParams productParams)
{
    var data = await _productRepository.GetProductsPagingAsync(productParams);
    return Ok(data);
}

    }
}