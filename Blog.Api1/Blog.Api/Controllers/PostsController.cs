using Blog.Common.Dtos;
using Blog.Common.Models.Post;
using Blog.Service.Api;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly PostService _postService;

        public PostsController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{postId:guid}")]
        public async Task<ActionResult<PostDto>> GetPostById(Guid postId)
        {
            var post = await _postService.GetPostById(postId);
            return Ok(post);
        }

        [HttpGet("blog/{blogId:guid}")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetBlogPosts(Guid userId,Guid blogId)
        {
            var posts = await _postService.GetBlogPosts(userId,blogId);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(Guid userId,Guid blogId, CreatePostModel createPostModel)
        {
            var createdPost = await _postService.AddPost(userId, blogId,createPostModel);
            return Ok(createdPost);
        }

        [HttpPut("{postId:guid}")]
        public async Task<ActionResult<PostDto>> UpdatePost(Guid userId, Guid blogId,Guid postId, UpdatePostModel updatePostDto)
        {
            var updatedPost = await _postService.UpdatePost(userId,blogId,postId, updatePostDto);
            return Ok(updatedPost);
        }

        [HttpDelete("{postId:guid}")]
        public async Task<IActionResult> DeletePost(Guid userId, Guid blogId, Guid postId)
        {
            var result = await _postService.DeletePost(userId, blogId, postId);
            return Ok(result);
        }
    }
}
