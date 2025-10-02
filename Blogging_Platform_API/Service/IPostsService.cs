using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Service
{
    public interface IPostsService
    {
        List<PostsDto> GetPosts(string? search = null, int page = 1, int limit = 10);
        PostsDto SavePosts(BlogPost blogPost);
        PostsDto UpdatePosts(string id, BlogPost blogPost);
        bool DeletePosts(string id);
        PostsDto GetPost(string id);
    }
}
