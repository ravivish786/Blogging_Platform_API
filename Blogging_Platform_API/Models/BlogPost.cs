using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogging_Platform_API.Models
{
    public class BlogPost
    {
        [BsonId] // MongoDB document Id
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;
        
        [JsonPropertyName("content")]
        public string Content { get; set; } = null!;
        
        [JsonPropertyName("category")]
        public string Category { get; set; } = null!;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = [];


        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; } = null;

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
