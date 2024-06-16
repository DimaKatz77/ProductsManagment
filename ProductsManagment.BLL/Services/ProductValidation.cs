using Microsoft.VisualBasic;
using ProductsManagment.Common.Common;
using ProductsManagment.Common.Common.Enums;
using ProductsManagment.Common.Common.Models;

namespace ProductsManagment.BLL.Services
{
    public class ProductValidation : IProductValidation
    {
        //Valid input Data
        public ResultDetails IsValid<T>(T _product)
        {
            if (_product == null)
            {
                return new ResultDetails(false, "Object is Null");
            }
          //Check is Input Type is product or Catalog
            Type genericType = typeof(T);
            if (genericType == typeof(ProductDto))
                return IsProductValid(_product as ProductDto);
            else if (genericType == typeof(CatalogDto))
                return IsCatalogValid(_product as CatalogDto);
            return new ResultDetails(true);
        }

        private ResultDetails IsCatalogValid(CatalogDto _catalog)
        {
            if (_catalog.Products== null)
                return new ResultDetails(true);
            //Check Products Duplicate - A Catalog can’t include a duplicate Product with the same id.
            var duplicates = FindDuplicates(_catalog.Products);
            if (duplicates.Count()>0)
            {
                return new ResultDetails(false, $"The catalog have a duplicate products, Id's -> {string.Join(", ", duplicates)}");
            }
            return new ResultDetails(true);
        }

        private ResultDetails IsProductValid(ProductDto _product)
        {
            //Is 
            if (_product.Category is FreshProductDTO f)
                return FreshMatch(f);
            else if (_product.Category is ElectricProductDTO e)
                return VoltageAndSocketTypeMatch(e);

            return new ResultDetails(true);
        }

        private List<string> FindDuplicates(IEnumerable<ProductDto> _products) {

            // A Catalog can’t include a duplicate Product with the same id.

            var idCounts = new Dictionary<string, int>();
            foreach (var item in _products)
            {
                if (idCounts.ContainsKey(item.Id))
                {
                    idCounts[item.Id]++;
                }
                else
                {
                    idCounts[item.Id] = 1;
                }
            }

            // Find IDs with more than one occurrence
            var duplicates = new List<string>();
            foreach (var kvp in idCounts)
            {
                if (kvp.Value > 1)
                {
                    duplicates.Add(kvp.Key);
                }
            }

            return duplicates;
        }

        private ResultDetails VoltageAndSocketTypeMatch(ElectricProductDTO _category)
        {
            //When adding a Product with the Electric category, validate that the voltage and socket type match. Matching rules are: 220v matching UK or EU sockets - 110v matching US socket
            if (_category.Voltage == Voltage._220V &&
                (_category.SocketType == SocketType.UK || _category.SocketType == SocketType.EU))
                return new ResultDetails(true);

            else if (_category.Voltage == Voltage._110V && _category.SocketType == SocketType.US)
                return new ResultDetails(true);

            return new ResultDetails(false, $"The Voltage {_category.Voltage} are not match to SocketType {_category.SocketType}");
        }

        private ResultDetails FreshMatch(FreshProductDTO _category)
        {
            //Products with the Fresh category can be added only if they have at least 7 days remaining until their expiry date - reference time check is UTC+0 at the time of product creation.

            if (_category.ExpiryDate > DateTime.UtcNow.AddDays(7))
            {
                return new ResultDetails(true);
            }
            return new ResultDetails(false, $"The Product is not Fresh, the expire date is {_category.ExpiryDate.ToShortDateString()}");
        }

    }
}
