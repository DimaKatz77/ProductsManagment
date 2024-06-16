using MongoDB.Bson;
using ProductsManagment.Common.Common.Models;
using ProductsManagment.DAL.Libs;
using ProductsManagment.DAL.Repository;

namespace ProductsManagment.BLL.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IMongoRepository<Catalog> _catalogRepository;

        public CatalogService(IMongoRepository<Catalog> catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<string> CreateCatalog(CatalogDto _catalogDto)
        {
            var catalog = MappingService.CatalogDtoToCatalog(_catalogDto);
            await _catalogRepository.InsertOneAsync(catalog);
            return catalog.Id.ToString();
        }

        public async Task DeleteCatalogAsync(string _id)
        {
            await _catalogRepository.DeleteByIdAsync(_id);
        }

        public async Task<IEnumerable<CatalogDto>> GetAllCatalogsAsunc()
        {
            var catalogs = await _catalogRepository.FindAllAsync();
            var dtoList = catalogs.Select(x => MappingService.CatalogToCatalogDto(x));
            return dtoList;
        }

        public IEnumerable<CatalogDto> GetAllCatalogsByProductId(string _id)
        {
            Product prod = new Product
            {
                Id = new ObjectId(_id),
            };
            var catalogs  = _catalogRepository.FilterBy(filter => filter.Products.Contains(prod));
            var dtoList = catalogs.Select(x => MappingService.CatalogToCatalogDto(x));
            return dtoList;
        }

        public async Task<CatalogDto> GetCatalogById(string id)
        {
            var catalog  =  await _catalogRepository.FindByIdAsync(id);
            return MappingService.CatalogToCatalogDto(catalog);
        }

        public async Task UpdateCatalogAsync(CatalogDto _catalogDto)
        {
            var catalog =  MappingService.CatalogDtoToCatalog(_catalogDto);
            await _catalogRepository.ReplaceOneAsync(catalog);
        }
    }
}
