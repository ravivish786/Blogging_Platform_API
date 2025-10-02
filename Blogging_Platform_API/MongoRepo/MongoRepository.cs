using Blogging_Platform_API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Blogging_Platform_API.MongoRepo
{
    public class MongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IOptions<MongoDbSettings> settings, string collectionName)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetAsync(string id) =>
            await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(string id, T entity)
        {
            // Ensure the entity's Id matches the existing document
            var property = typeof(T).GetProperty("Id");
            if (property != null)
            {
                property.SetValue(entity, id); // assign Id from route
            }

            await _collection.ReplaceOneAsync(
                Builders<T>.Filter.Eq("Id", id),
                entity
            );
        }

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
    }
}
