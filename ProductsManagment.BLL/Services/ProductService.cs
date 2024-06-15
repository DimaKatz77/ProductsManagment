using AutoMapper;
using ProductsManagment.DAL.Libs;
using ProductsManagment.DAL.Repository;
using ProductsManagment.Models.DTO;

namespace ProductsManagment.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMongoRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateProductAsync(ProductDTO _product)
        {
            var item = _mapper.Map<Product>(_product);
            await _productRepository.InsertOneAsync(item);
            return _product.Id.ToString();
        }

        public async Task DeleteProductAsync(string _id)
        {
            await _productRepository.DeleteByIdAsync(_id);
        }

        public async Task UpdateProductAsync(ProductDTO _product)
        {
            var item = _mapper.Map<Product>(_product);
            await _productRepository.ReplaceOneAsync(item);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsunc()
        {
            var items = await _productRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(items);
        }

        public async Task<ProductDTO> GetProductById(string id)
        {
            var item = await _productRepository.FindByIdAsync(id);
            return _mapper.Map<ProductDTO>(item);
        }

        public IEnumerable<ProductDTO> GetProductsByCategory<T>()
        {
            var items =  _productRepository.FilterBy(c => c.Category is T);
            return _mapper.Map<IEnumerable<ProductDTO>>(items);
        }

        public IEnumerable<ProductDTO> GetProductsByPriceLimit(decimal _price)
        {
            var items = _productRepository.FilterBy(filter => filter.Price < _price);
            return _mapper.Map<IEnumerable<ProductDTO>>(items);
        }

    }
}
