using AutoMapper;
using ProductsManagment.DAL.Libs;
using ProductsManagment.DAL.Repository;

namespace ProductsManagment.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoRepository<Product> _productRepository;

        public ProductService(IMongoRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> CreateProductAsync(Product _product)
        {
            await _productRepository.InsertOneAsync(_product);
            return _product.Id.ToString();
        }

        public async Task DeleteProductAsync(string _id)
        {
            await _productRepository.DeleteByIdAsync(_id);
        }

        public async Task UpdateProductAsync(Product _product)
        {
            await _productRepository.ReplaceOneAsync(_product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsunc()
        {
            return await _productRepository.FindAllAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _productRepository.FindByIdAsync(id);
        }

        public IEnumerable<Product> GetProductsByCategory<T>()
        {
            return   _productRepository.FilterBy(c => c.Category is T);
        }

        public IEnumerable<Product> GetProductsByPriceLimit(decimal _price)
        {
            return _productRepository.FilterBy(filter => filter.Price < _price);
        }

    }
}
