using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using ProductsManagment.BLL.Services;
using ProductsManagment.Models;
using ProductsManagment.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace ProductsManagment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductValidation _productValidation;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Create new Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO _product)
        {
            //Validate the 
            var _validationResult = _productValidation.IsValid(_product);
            if (!_validationResult.IsSuccess)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Is Not Valid a Product",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = _validationResult.Message
                });
            }

            string _productId = await _productService.CreateProductAsync(_product);

            return Ok(_productId);
        }

        //Update Product
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id,  [FromBody] ProductDTO _product)
        {

            //Validate the 
            var _validationResult = _productValidation.IsValid(_product);
            if (!_validationResult.IsSuccess)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Is Not Valid a Product",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = _validationResult.Message
                });
            }

            var product = await _productService.GetProductById(id);
            if (product is null)
                return NotFound();

            await _productService.UpdateProductAsync(_product);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllProductsAsunc();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string _id)
        {
            var product = await _productService.GetProductById(_id);
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string _id)
        {
            await _productService.DeleteProductAsync(_id);
            return NoContent();
        }

        [HttpGet("{priceLimit}")]
        public IActionResult GetByPriceLimit(int _priceLimit)
        {
            var products = _productService.GetProductsByPriceLimit(_priceLimit);
            return Ok(products);
        }

        [HttpGet("{category}")]
        public IActionResult GetByCategory(string _category)
        {
            IEnumerable<ProductDTO> products;
            if (_category == "fresh")
                products = _productService.GetProductsByCategory<FreshProductDTO>();
            else if (_category == "electric")
                products = _productService.GetProductsByCategory<ElectricProductDTO>();
            else
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "fresh - is Fresh Products, electric is Electric Product",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = $"{_category} is bad request category"
                });
            }
            return Ok(products);
        }


    }
}
