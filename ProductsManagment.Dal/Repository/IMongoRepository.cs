using MongoDB.Driver;
using ProductsManagment.DAL.Libs;
using System.Linq.Expressions;

namespace ProductsManagment.DAL.Repository
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
        IEnumerable<TDocument> FilterBy(FilterDefinition<TDocument>? filter);

    }
}
