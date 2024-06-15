
namespace ProductsManagment.Models.DTO
{
    public class CatalogDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
