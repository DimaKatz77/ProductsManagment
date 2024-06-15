using Microsoft.AspNetCore.Mvc;

namespace ProductsManagment.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
