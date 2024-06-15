using ProductsManagment.DAL.Libs;
using ProductsManagment.DAL.Libs.Enums;
using ProductsManagment.ErrorHandling.Middleware;
using ProductsManagment.Models.DTO;

namespace ProductsManagment.BLL.Services
{
    public class ProductValidation : IProductValidation
    {
        public ResultDetails IsValid(ProductDTO _product)
        {
            if (_product.Category is FreshProductDTO f)
                return FreshMatch(f);
            else if (_product.Category is ElectricProductDTO e)
                return VoltageAndSocketTypeMatch(e);

            return new ResultDetails(true);
        }

        private ResultDetails VoltageAndSocketTypeMatch(ElectricProductDTO _category)
        {
            if (_category.Voltage == VoltageDTO._220V &&
                (_category.SocketType == SocketTypeDTO.UK || _category.SocketType == SocketTypeDTO.EU))
                return new ResultDetails(true);

            else if (_category.Voltage == VoltageDTO._110V && _category.SocketType == SocketTypeDTO.US)
                return new ResultDetails(true);

            return new ResultDetails(false, $"The Voltage {_category.Voltage} are not match to SocketType {_category.SocketType}");
        }

        private ResultDetails FreshMatch(FreshProductDTO _category)
        {
            if (_category.ExpiryDate > DateTime.UtcNow.AddDays(7))
            {
                return new ResultDetails(true);
            }
            return new ResultDetails(false, $"The Product is not Fresh, the expire date is {_category.ExpiryDate.ToShortDateString()}");
        }

    }
}
