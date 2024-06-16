
using ProductsManagment.Common.Common;
using ProductsManagment.Common.Common.Enums;
using ProductsManagment.Common.Common.Libs;

namespace ProductsManagment.BLL.Services
{
    public class ProductValidation : IProductValidation
    {
        public ResultDetails IsValid(Product _product)
        {
            if (_product.Category is FreshProduct f)
                return FreshMatch(f);
            else if (_product.Category is ElectricProduct e)
                return VoltageAndSocketTypeMatch(e);

            return new ResultDetails(true);
        }

        private ResultDetails VoltageAndSocketTypeMatch(ElectricProduct _category)
        {
            if (_category.Voltage == Voltage._220V &&
                (_category.SocketType == SocketType.UK || _category.SocketType == SocketType.EU))
                return new ResultDetails(true);

            else if (_category.Voltage == Voltage._110V && _category.SocketType == SocketType.US)
                return new ResultDetails(true);

            return new ResultDetails(false, $"The Voltage {_category.Voltage} are not match to SocketType {_category.SocketType}");
        }

        private ResultDetails FreshMatch(FreshProduct _category)
        {
            if (_category.ExpiryDate > DateTime.UtcNow.AddDays(7))
            {
                return new ResultDetails(true);
            }
            return new ResultDetails(false, $"The Product is not Fresh, the expire date is {_category.ExpiryDate.ToShortDateString()}");
        }

    }
}
