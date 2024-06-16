using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using ProductsManagment.Common.Common.Models;
using ProductsManagment.DAL.Libs;
using ProductsManagment.DAL.Repository;
using System.Collections.Generic;

namespace ProductsManagment.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoRepository<Product> _productRepository;

        public ProductService(IMongoRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> CreateProductAsync(ProductDto _productDto)
        {
            Product _product = MappingService.ProductDtoToProduct(_productDto);
            await _productRepository.InsertOneAsync(_product);
            return _product.Id.ToString();
        }

        public async Task DeleteProductAsync(string _id)
        {
            await _productRepository.DeleteByIdAsync(_id);
        }

        public async Task UpdateProductAsync(ProductDto _productDto)
        {
            Product _product = MappingService.ProductDtoToProduct(_productDto);
            await _productRepository.ReplaceOneAsync(_product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsunc()
        {
            var products = await _productRepository.FindAllAsync();
            var dtoList = products.Select(x => MappingService.ProductToProductDTO(x));
            return dtoList;
        }

        public async Task<ProductDto> GetProductById(string id)
        {
            return MappingService.ProductToProductDTO(await _productRepository.FindByIdAsync(id));
        }

        public IEnumerable<ProductDto> GetProductsByCategory(ProductCategory category)
        {
            IEnumerable<Product> products = new List<Product>();
            switch (category)
            {
                case ProductCategory.fresh:
                    products = _productRepository.FilterBy(c => c.Category is FreshProduct);
                    break;
                case ProductCategory.electric:
                    products = _productRepository.FilterBy(c => c.Category is ElectricProduct);
                    break;
                default:
                    products = null;
                    break;
            }
            
            var dtoList = products.Select(x => MappingService.ProductToProductDTO(x));
            return dtoList;
        }

        public IEnumerable<ProductDto> GetProductsByPriceLimit(decimal _price)
        {
            var products = _productRepository.FilterBy(filter => filter.Price <= _price);
            var dtoList = products.Select(x => MappingService.ProductToProductDTO(x));
            return dtoList;
        }
    }
}
