using ProductsManagment.DAL.Libs;
using ProductsManagment.Models.DTO;

namespace ProductsManagment.BLL.Services
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(ProductDTO _product);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsunc();
        Task<ProductDTO> GetProductById(string id);
        IEnumerable<ProductDTO> GetProductsByCategory<T>();
        IEnumerable<ProductDTO> GetProductsByPriceLimit(decimal _price);
        Task UpdateProductAsync(ProductDTO _product);
        Task DeleteProductAsync(string _id);


    }
}
