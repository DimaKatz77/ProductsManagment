using Microsoft.AspNetCore.Mvc;
using ProductsManagment.BLL.Services;
using ProductsManagment.Common.Common.Enums;
using ProductsManagment.Common.Common.Models;
using ProductsManagment.DAL.Libs;

namespace ProductsManagment.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IProductValidation _productValidation;

        public CatalogController(
            ICatalogService catalogService,
            IProductValidation productValidation)
        {
            _catalogService = catalogService;
            _productValidation = productValidation;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CatalogDto _catalog)
        {
            //Validate the _product
            var _validationResult = _productValidation.IsValid(_catalog);
            if (!_validationResult.IsSuccess)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Is Not Valid a Product",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = _validationResult.Message
                });
            }

            string _catalogId = await _catalogService.CreateCatalog(_catalog);

            return Ok(_catalogId);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var catalogs = await _catalogService.GetAllCatalogsAsunc();
            return Ok(catalogs);
        }

        [HttpGet("get-by-id{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var _catalog = await _catalogService.GetCatalogById(id);
            if (_catalog is null)
                return NotFound();

            return Ok(_catalog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _catalogService.DeleteCatalogAsync(id);
            return NoContent();
        }

        //Update Product
        [HttpPut]
        public async Task<IActionResult> Put(CatalogDto _catalog)
        {
            var catalog = await _catalogService.GetCatalogById(_catalog.Id);
            if (catalog is null)
                return NotFound();

            await _catalogService.UpdateCatalogAsync(_catalog);
            return NoContent();
        }

        [HttpGet("get-by-product-id/{productId}")]
        public IActionResult GetByProductId(string productId)
        {
            var products = _catalogService.GetAllCatalogsByProductId(productId);
            return Ok(products);
        }

    }
}
