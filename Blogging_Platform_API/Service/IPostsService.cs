using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Service
{
    public interface IPostsService
    {
        Task<List<PostsDto>> GetPostsAsync(string? search = null, int page = 1, int limit = 10);
        Task<PostsDto> SavePostAsync(BlogPost blogPost);
        Task<PostsDto> UpdatePostAsync(string id, BlogPost blogPost);
        Task DeletePostAsync(string id);
        Task<PostsDto> GetPostAsync(string id);
    }
}
