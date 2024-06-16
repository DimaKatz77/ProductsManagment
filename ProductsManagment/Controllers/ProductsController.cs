using Microsoft.AspNetCore.Mvc;
using ProductsManagment.BLL.Services;
using ProductsManagment.Common.Common.Models;

namespace ProductsManagment.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductValidation _productValidation;

        public ProductsController(IProductService productService, IProductValidation productValidation)
        {
            _productService = productService;
            _productValidation = productValidation;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto _product)
        {
            //Validate the _product
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

        [HttpPut]
        public async Task<IActionResult> Put(ProductDto _product)
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

            var product = await _productService.GetProductById(_product.Id);
            if (product is null)
                return NotFound();

            await _productService.UpdateProductAsync(_product);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await _productService.GetAllProductsAsunc();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetProductById(id);
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }

        [HttpGet("price-limit/{limit}")]
        public IActionResult GetByPriceLimit(decimal limit)
        {
            var products = _productService.GetProductsByPriceLimit(limit);
            return Ok(products);
        }

        [HttpGet("by-category{category}")]
        public IActionResult GetByCategory(ProductCategory category)
        {
            IEnumerable<ProductDto> products = _productService.GetProductsByCategory(category); ;

            return Ok(products);
        }


    }
}
