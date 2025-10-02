using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blogging_Platform_API.Models
{
    public class BlogPost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = null; 

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;
        
        [JsonPropertyName("content")]
        public string Content { get; set; } = null!;
        
        [JsonPropertyName("category")]
        public string Category { get; set; } = null!;

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = [];


        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
