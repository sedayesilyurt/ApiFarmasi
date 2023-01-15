using ApiFarmasi.Models;
using ApiFarmasi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace ApiFarmasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductsService _productService;

        public ProductController(ProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Products>> Get() =>
            await _productService.GetAsync();

        //[HttpGet]
        //public async Task<ActionResult<Products>> Get(string id)
        //{
        //    var product = await _productService.GetAsync(id);

        //    if (product is null)
        //    {
        //        return NotFound();
        //    }

        //    return product;
        //}

        [HttpPost]
        public async Task<IActionResult> Post(Products newProduct)
        {
            await _productService.CreateAsync(newProduct);

            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Products updatedProduct)
        {
            var book = await _productService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedProduct.Id = book.Id;

            await _productService.UpdateAsync(id, updatedProduct);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _productService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _productService.RemoveAsync(id);

            return NoContent();
        }
    }
}
