using ProductsManagment.Common.Common;

namespace ProductsManagment.BLL.Services
{
    public interface IProductValidation
    {
        ResultDetails IsValid<T>(T _obj);
    }
}
