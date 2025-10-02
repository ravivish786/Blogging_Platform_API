using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Helper;
using Blogging_Platform_API.Models;
using Blogging_Platform_API.MongoRepo;
using MongoDB.Bson;
using SharpCompress.Common;

namespace Blogging_Platform_API.Service
{
    public class PostsService : IPostsService
    {
        private readonly MongoRepository<BlogPost> _postsRepo;

        public PostsService(MongoRepository<BlogPost> postsRepo)
        {
            _postsRepo = postsRepo;
        }

        public bool DeletePosts(string id)
        {
            _postsRepo.Remove(id);
            return true;
        }

        public PostsDto GetPost(string id)
        {
            var data = _postsRepo.Get(id);

            if (data == null)
            {
                return default;
            }

            return PostMapper.ToDto(data);
        }
 
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

            // Generate ObjectId if not provided
            if (string.IsNullOrEmpty(blogPost.Id))
            {
                blogPost.Id = ObjectId.GenerateNewId().ToString();
            }

            var data = _postsRepo.Create(blogPost);

            return PostMapper.ToDto(data);
        }

        public PostsDto UpdatePosts(string id, BlogPost blogPost)
        {
            _postsRepo.Update(id, blogPost);
            return PostMapper.ToDto(blogPost);
        }
    }
}
