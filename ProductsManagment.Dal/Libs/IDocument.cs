using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductsManagment.DAL.Libs
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
