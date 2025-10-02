namespace Blogging_Platform_API.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string PostsCollectionName { get; set; }
    }

}
