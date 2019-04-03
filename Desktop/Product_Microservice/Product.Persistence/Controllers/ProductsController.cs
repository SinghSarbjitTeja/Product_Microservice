using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Product.Persistence.Domain.Contracts;
using Product.Persistence.Models;
using Product.Persistence.Repository;

namespace Product.Persistence.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <remarks>
        /// Get product by id
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return new OkObjectResult(product);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Error while Getting Product", e });
            }
        }


        /// <summary>
        /// Get list of products
        /// </summary>
        /// <remarks>
        /// Get list of products
        /// </remarks>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _productService.GetProductList();
                return new OkObjectResult(products);
            }
            catch (Exception e)
            {

                return Json(new { Success = false, Message = "Error while getting the list", e });
            }
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <remarks>
        /// Create a product
        /// </remarks>    
        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Parameter can not be null" });
            }
            var result = _productService.AddNewProduct(product);
            if (result)
            {
                return Json(new { Success = true, Message = "New Product added succesfullly" });
            }
            else
            {
                return Json(new { Success = false, Message = "Error while adding new language" });
            }
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <remarks>
        /// Update a product
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Parameter can not be null" });
            }
            if (product != null)
            {
                var res = await _productService.UpdateProduct(product);
                if (res)
                {
                    return new OkObjectResult(new { Message = "updated successfully" });
                }
            }
            return new NoContentResult();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <remarks>
        /// Delete a product
        /// </remarks>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _productService.DeleteProduct(id);
                if (res)
                {
                    return new OkObjectResult(new { Message = "Deleted Product successfully" });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Could not delete" });
            }
            return new NoContentResult();
        }
    }
}
