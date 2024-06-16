

using ProductsManagment.Common.Common;
using ProductsManagment.Common.Common.Libs;

namespace ProductsManagment.BLL.Services
{
    public interface IProductValidation
    {
        ResultDetails IsValid(Product _product);
    }
}
