using ProductsManagment.Common.Common.Models;

namespace ProductsManagment.BLL.Services
{
    public interface ICatalogService
    {
        Task<string> CreateCatalog(CatalogDto _catalog);

        Task<IEnumerable<CatalogDto>> GetAllCatalogsAsunc();

        Task<CatalogDto> GetCatalogById(string _id);

        IEnumerable<CatalogDto> GetAllCatalogsByProductId(string _id);

        Task UpdateCatalogAsync(CatalogDto _catalog);

        Task DeleteCatalogAsync(string _id);
    }
}
