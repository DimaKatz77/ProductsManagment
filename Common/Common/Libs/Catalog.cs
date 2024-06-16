using MongoDB.Bson.Serialization.Attributes;

namespace ProductsManagment.DAL.Libs
{
    [BsonCollection("catalog")]
    public class Catalog : Document
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonIgnoreIfNull]
        public IEnumerable<Product> Products { get; set; }
    }
}
