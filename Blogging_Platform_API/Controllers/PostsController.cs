using Blogging_Platform_API.Models;
using Blogging_Platform_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blogging_Platform_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService, ILogger<PostsController> logger)
        {
            this.postsService = postsService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetPosts([FromQuery] string? search = null, [FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            // Example result (replace with DB logic)
            var posts = new
            {
                Search = search,
                Paging = new { Page = page, Limit = limit },
                Data = postsService.GetPosts(search, page, limit)
            };

            return Ok(posts);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public IActionResult GetPostById([FromRoute] string id)
        {
            var post = postsService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }   

        [HttpPost]
        public IActionResult PostPosts([FromBody] BlogPost blogPost)
        {
            var result =  postsService.SavePosts(blogPost);

            // Return 201 Created + Location header
            return CreatedAtAction(
                nameof(GetPostById),                // Action name to generate URL
                new { id = result.Id },             // Route values
                result                              // Response body
            );
        }

        [HttpPut("{id}", Name = "UpdatePost")]
        public IActionResult UpdatePost(string id,  [FromBody] BlogPost post)
        {
            var response = postsService.GetPost(id);

            if (response == null)
            {
                return NotFound();
            }
            post.CreatedAt = response.CreatedAt;
            post.UpdatedAt = DateTime.UtcNow;

            var result = postsService.UpdatePosts(id, post);

            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public IActionResult DeletePost(string id)
        {
            var data = postsService.GetPost(id);

            if (data == null)
            {
                return NotFound();
            }

            _ = postsService.DeletePosts(id);
            return NoContent();
        }

    }
}
