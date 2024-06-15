using ProductsManagment.ErrorHandling.Middleware;
using ProductsManagment.Models.DTO;

namespace ProductsManagment.BLL.Services
{
    public interface IProductValidation
    {
        ResultDetails IsValid(ProductDTO _product);
    }
}
