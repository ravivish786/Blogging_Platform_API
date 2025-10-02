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

        public List<T> Get() =>
            _collection.Find(_ => true).ToList();

        public T Get(string id) =>
            _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefault();

        public T Create(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        //public void Update(string id, T entity) =>
        //    _collection.ReplaceOne(Builders<T>.Filter.Eq("Id", id), entity);

        public void Update(string id, T entity)
        {
            // Ensure the entity's Id matches the existing document
            var property = typeof(T).GetProperty("Id");
            if (property != null)
            {
                property.SetValue(entity, id); // assign Id from route
            }

            _collection.ReplaceOne(
                Builders<T>.Filter.Eq("Id", id),
                entity
            );
        }


        public void Remove(string id) =>
            _collection.DeleteOne(Builders<T>.Filter.Eq("Id", id));
    }
}
