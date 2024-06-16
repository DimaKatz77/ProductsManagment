using Microsoft.AspNetCore.Mvc;
using ProductsManagment.BLL.Services;
using ProductsManagment.Common.Common.Enums;
using ProductsManagment.Common.Common.Libs;

namespace ProductsManagment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Catalog _catalog)
        {
            _catalog = new Catalog
            {
               Title = "Cat1",
            };

            string _catalogId = await _catalogService.CreateCatalog(_catalog);

            return Ok(_catalogId);
        }

        [HttpGet("{GetAll}")]
        public async Task<IActionResult> Get()
        {
            var catalogs = await _catalogService.GetAllCatalogsAsunc();
            return Ok(catalogs);
        }

        [HttpGet("{id}")]
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

        public IActionResult Index()
        {
            return View();
        }

        //Update Product
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product _product)
        {
            var _catalog = await _catalogService.GetCatalogById(id);
            if (_catalog is null)
                return NotFound();

            await _catalogService.UpdateCatalogAsync(_catalog);
            return NoContent();
        }

        [HttpGet("GetByProductId/{productId}")]
        public  IActionResult GetByPriceLimit(string productId)
        {
            var products =  _catalogService.GetAllCatalogsByProductId(productId);
            return Ok(products);
        }

    }
}
