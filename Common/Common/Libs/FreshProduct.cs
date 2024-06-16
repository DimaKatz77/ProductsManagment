using MongoDB.Bson.Serialization.Attributes;

namespace ProductsManagment.DAL.Libs
{
    public class FreshProduct : Category
    {
        [BsonElement("expiryDate")]
        public DateTime ExpiryDate { get; set; }
    }
}
