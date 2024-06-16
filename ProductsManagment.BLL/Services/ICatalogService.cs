
using ProductsManagment.Common.Common.Libs;

namespace ProductsManagment.BLL.Services
{
    public interface ICatalogService
    {
        Task<string> CreateCatalog(Catalog _catalog);

        Task<IEnumerable<Catalog>> GetAllCatalogsAsunc();

        Task<Catalog> GetCatalogById(string _id);

        IEnumerable<Catalog> GetAllCatalogsByProductId(string _id);

        Task UpdateCatalogAsync(Catalog _catalog);

        Task DeleteCatalogAsync(string _id);
    }
}
