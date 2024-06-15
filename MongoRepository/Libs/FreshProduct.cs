using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Libs
{
    public class FreshProduct : Category
    {
        [BsonElement("expiryDate")]
        public DateTime ExpiryDate { get; set; }
    }
}
