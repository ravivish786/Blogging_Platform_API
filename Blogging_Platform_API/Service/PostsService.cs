using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Helper;
using Blogging_Platform_API.Models;
using Blogging_Platform_API.MongoRepo;
using MongoDB.Bson;

namespace Blogging_Platform_API.Service
{
    public class PostsService : IPostsService
    {
        private readonly MongoRepository<BlogPost> _postsRepo;

        public PostsService(MongoRepository<BlogPost> postsRepo)
        {
            _postsRepo = postsRepo;
        }

        public async Task DeletePostAsync(string id)
        {
            await _postsRepo.RemoveAsync(id);
        }

        public async Task<PostsDto> GetPostAsync(string id)
        {
            var data = await _postsRepo.GetAsync(id);

            if (data == null)
            {
                return default;
            }

            return PostMapper.ToDto(data);
        }
 
        public async Task<List<PostsDto>> GetPostsAsync(string? search = null, int page = 1, int limit = 10)
        {
            var data = await _postsRepo.GetAsync();

            if (data == null)
            {
                return default;
            }

            return PostMapper.ToDtoList(data);
        }

        public async Task<PostsDto> SavePostAsync(BlogPost blogPost)
        {

            // Generate ObjectId if not provided
            if (string.IsNullOrEmpty(blogPost.Id))
            {
                blogPost.Id = ObjectId.GenerateNewId().ToString();
            }
            blogPost.CreatedAt = DateTime.UtcNow;
            var data = await _postsRepo.CreateAsync(blogPost);

            return PostMapper.ToDto(data);
        }

        public async Task<PostsDto> UpdatePostAsync(string id, BlogPost blogPost)
        {
            await _postsRepo.UpdateAsync(id, blogPost);
            return PostMapper.ToDto(blogPost);
        }
    }
}
