namespace ProductsManagment.Models.DTO
{
    public class ProductDTO
    {
            public string Id { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public decimal Price { get; set; }

            public bool IsActive { get; set; }

            public CategoryDto Category { get; set; }
    }
}
