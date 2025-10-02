using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Models;

namespace Blogging_Platform_API.Service
{
    public class PostsService : IPostsService
    {
        public bool DeletePosts(int id)
        {
            throw new NotImplementedException();
        }

        public PostsDto GetPost(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get posts with optional search and paging.
        /// </summary>
        /// <param name="search">Search keyword</param>
        /// <param name="page">Page number (default = 1)</param>
        /// <param name="limit">Page size (default = 10)</param>
        /// <returns>List of posts</returns>
        public List<PostsDto> GetPosts(string? search = null, int page = 1, int limit = 10)
        {
            throw new NotImplementedException();
        }

        public PostsDto SavePosts(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public PostsDto UpdatePosts(int id, BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
