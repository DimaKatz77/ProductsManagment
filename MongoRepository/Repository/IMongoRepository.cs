using DataAccessLayer.Libs;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task InsertOneAsync(TDocument document);
        Task<IEnumerable<TDocument>> FindAllAsync();
        Task<TDocument> FindByIdAsync(string id);
        Task DeleteByIdAsync(string id);
        Task ReplaceOneAsync(TDocument document);
        IEnumerable<TDocument> FilterBy(
        Expression<Func<TDocument, bool>> filterExpression);

    }
}
