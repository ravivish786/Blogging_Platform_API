using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Helper;
using Blogging_Platform_API.Models;
using Blogging_Platform_API.MongoRepo;

namespace Blogging_Platform_API.Service
{
    public class PostsService : IPostsService
    {
        private readonly MongoRepository<BlogPost> _postsRepo;

        public PostsService(MongoRepository<BlogPost> postsRepo)
        {
            _postsRepo = postsRepo;
        }

        public bool DeletePosts(int id)
        {
            _postsRepo.Remove(id.ToString());
            return true;
        }

        public PostsDto GetPost(int id)
        {
            var data = _postsRepo.Get(id.ToString());

            if (data == null)
            {
                return default;
            }

            return PostMapper.ToDto(data);
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
            var data = _postsRepo.Get();

            if (data == null)
            {
                return default;
            }

            return PostMapper.ToDtoList(data);
        }

        public PostsDto SavePosts(BlogPost blogPost)
        {
            var data = _postsRepo.Create(blogPost);
            return PostMapper.ToDto(data);
        }

        public PostsDto UpdatePosts(int id, BlogPost blogPost)
        {
            _postsRepo.Update(id.ToString(), blogPost);
            return PostMapper.ToDto(blogPost);
        }
    }
}
