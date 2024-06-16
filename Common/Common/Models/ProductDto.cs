using System.Text.Json.Serialization;

namespace ProductsManagment.Common.Common.Models
{
    public class ProductDto
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("category")]
        public CategoryDto Category { get; set; }
    }
}
