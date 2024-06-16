using ProductsManagment.DAL.Libs;

namespace ProductsManagment.BLL.Services
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(Product _product);
        Task<IEnumerable<Product>> GetAllProductsAsunc();
        Task<Product> GetProductById(string id);
        IEnumerable<Product> GetProductsByCategory<T>();
        IEnumerable<Product> GetProductsByPriceLimit(decimal _price);
        Task UpdateProductAsync(Product _product);
        Task DeleteProductAsync(string _id);


    }
}
