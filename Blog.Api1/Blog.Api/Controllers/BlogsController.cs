using Blog.Common.Dtos;
using Blog.Common.Models.Blog;
using Blog.Service.Api;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : Controller
    {
        private readonly BlogService _blogService;

        public BlogsController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDto>>> GetAllBlogs(Guid userId)
        {
            var blogs = await _blogService.GetAllUserBlogs(userId);
            return Ok(blogs);
        }

        [HttpGet("{blogId:guid}")]
        public async Task<ActionResult<BlogDto>> GetBlogByUserId(Guid userId, Guid blogId)
        {
            var blog = await _blogService.GetBlogByUserId(userId, blogId);
            return Ok(blog);
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<IEnumerable<BlogDto>>> GetUserBlogs(Guid userId)
        {
            var blogs = await _blogService.GetAllUserBlogs(userId);
            return Ok(blogs);
        }

        [HttpPost]
        public async Task<ActionResult<BlogDto>> CreateBlog(Guid userId, CreateBlogModel createBlogDto)
        {
            var createdBlog = await _blogService.AddBlog(userId, createBlogDto);
            return Ok(createdBlog);
        }

        [HttpPut("{blogId:guid}")]
        public async Task<ActionResult<BlogDto>> UpdateBlog(Guid userId, Guid blogId, UpdateBlogModel updateBlogDto)
        {
            var updatedBlog = await _blogService.UpdateBlog(userId, blogId, updateBlogDto);
            return Ok(updatedBlog);
        }

        [HttpDelete("{blogId:guid}")]
        public async Task<IActionResult> DeleteBlog(Guid userId,Guid blogId)
        {
            var result = await _blogService.DeleteBlog(userId,blogId);
            return Ok(result);
        }
    }
}
