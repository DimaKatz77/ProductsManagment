

using ProductsManagment.Common.Common;
using ProductsManagment.DAL.Libs;

namespace ProductsManagment.BLL.Services
{
    public interface IProductValidation
    {
        ResultDetails IsValid(Product _product);
    }
}
