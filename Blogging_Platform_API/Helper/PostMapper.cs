using Blogging_Platform_API.DTO;
using Blogging_Platform_API.Models;
using Microsoft.Extensions.Hosting;

namespace Blogging_Platform_API.Helper
{
    public static class PostMapper
    {
        public static PostsDto ToDto(BlogPost post) => new PostsDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Category = post.Category,
            Tags = post.Tags,
            CreatedAt = post.CreatedAt ?? DateTime.MinValue,
            UpdatedAt = post.UpdatedAt ?? DateTime.MinValue,
        };

        public static List<PostsDto> ToDtoList(List<BlogPost> posts) => posts.Select(x => ToDto(x)).ToList();

        public static BlogPost ToEntity(PostsDto dto) => new BlogPost
        {
            Id = dto.Id,
            Title = dto.Title,
            Content = dto.Content,
            Category = dto.Category,
            Tags = dto.Tags,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };
    }

}
