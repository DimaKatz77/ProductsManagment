using Microsoft.AspNetCore.Mvc;
using ProductsManagment.BLL.Services;
using ProductsManagment.Common.Common.Enums;
using ProductsManagment.DAL.Libs;

namespace ProductsManagment.Controllers
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


        //Create new Product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product _product)
        {
            _product = new Product
            {
                Category = new ElectricProduct
                {
                    SocketType = SocketType.UK,
                    Voltage = Voltage._220V
                },
                Description = "MyTest",
                IsActive = true,
                Price = 45,
                Title = ""
            };
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
        public async Task<IActionResult> Put(string id,  [FromBody] Product _product)
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
            return NoContent();
        }

        [HttpGet("{GetAll}")]
        public async Task<IActionResult> Get()
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

        [HttpGet("GetByPriceLimit/{priceLimit}")]
        public IActionResult GetByPriceLimit(int priceLimit)
        {
            var products = _productService.GetProductsByPriceLimit(priceLimit);
            return Ok(products);
        }

        [HttpGet("GetByCategory/{category}")]
        public IActionResult GetByCategory(string category)
        {
            IEnumerable<Product> products;
            if (category == "fresh")
                products = _productService.GetProductsByCategory<FreshProduct>();
            else if (category == "electric")
                products = _productService.GetProductsByCategory<ElectricProduct>();
            else
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "fresh - is Fresh Products, electric is Electric Product",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = $"{category} is bad request category"
                });
            }
            return Ok(products);
        }


    }
}
