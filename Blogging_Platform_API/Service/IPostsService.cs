using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Service
{
    public interface IPostsService
    {
        List<PostsDto> GetPosts(string? search = null, int page = 1, int limit = 10);
        PostsDto SavePosts(BlogPost blogPost);
        PostsDto UpdatePosts(int id, BlogPost blogPost);
        bool DeletePosts(int id);
        PostsDto GetPost(int id);
    }
}
