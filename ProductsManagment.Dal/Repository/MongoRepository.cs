using MongoDB.Bson;
using MongoDB.Driver;
using ProductsManagment.Common.Common;
using ProductsManagment.Common.Common.Libs;
using System.Linq.Expressions;

namespace ProductsManagment.DAL.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument>
    where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;
        public MongoRepository(DBSettings _dbSettings)
        {

            var _database = new MongoClient(_dbSettings.ConnectionString).GetDatabase(_dbSettings.DatabaseName);
            _collection = _database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }


        public virtual Task InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public virtual Task<IEnumerable<TDocument>> FindAllAsync()
        {
            return Task.Run(() => _collection.Find(new BsonDocument()).ToEnumerable());
        }


        public virtual Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {

                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public virtual IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }
    }


}
