using MongoDB.Bson;

namespace DataAccessLayer.Libs
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
