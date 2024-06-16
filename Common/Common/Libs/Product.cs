using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductsManagment.DAL.Libs
{
    [BsonCollection("Product")]
    public class Product : Document
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("isActive")]
        public bool IsActive { get; set; }

        [BsonElement("category")]
        public Category Category { get; set; }
    }
}
