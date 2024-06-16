using MongoDB.Bson;
using ProductsManagment.Common.Common.Libs;
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

        public async Task<string> CreateCatalog(Catalog _catalog)
        {
            await _catalogRepository.InsertOneAsync(_catalog);
            return _catalog.Id.ToString();
        }

        public async Task DeleteCatalogAsync(string _id)
        {
            await _catalogRepository.DeleteByIdAsync(_id);
        }

        public async Task<IEnumerable<Catalog>> GetAllCatalogsAsunc()
        {
            return await _catalogRepository.FindAllAsync();
        }

        public IEnumerable<Catalog> GetAllCatalogsByProductId(string _id)
        {
            Product prod = new Product
            {
                Id = new ObjectId(_id),
            };
            return _catalogRepository.FilterBy(filter => filter.Products.Contains(prod));
        }

        public async Task<Catalog> GetCatalogById(string id)
        {
            return await _catalogRepository.FindByIdAsync(id);
        }

        public async Task UpdateCatalogAsync(Catalog _catalog)
        {
            await _catalogRepository.ReplaceOneAsync(_catalog);
        }


    }
}
