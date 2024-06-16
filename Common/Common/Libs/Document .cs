using MongoDB.Bson;

namespace ProductsManagment.DAL.Libs
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
