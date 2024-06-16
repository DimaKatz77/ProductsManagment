using ProductsManagment.Common.Common.Models;

namespace ProductsManagment.BLL.Services
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(ProductDto _product);
        Task<IEnumerable<ProductDto>> GetAllProductsAsunc();
        Task<ProductDto> GetProductById(string _id);
        IEnumerable<ProductDto> GetProductsByCategory(ProductCategory _category);
        IEnumerable<ProductDto> GetProductsByPriceLimit(decimal _price);
        Task UpdateProductAsync(ProductDto _product);
        Task DeleteProductAsync(string _id);


    }
}
