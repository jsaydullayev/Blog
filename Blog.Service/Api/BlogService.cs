using Blog.Common.Dtos;
using Blog.Common.Models.Blog;
using Blog.Data;
using Blog.Data.Entities;
using Blog.Data.Repository;
using Blog.Service.Extensions;

namespace Blog.Service.Api
{
    public class BlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUserRepository _userRepository;
        public BlogService(IBlogRepository blogRepository,IUserRepository userRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }
        public async Task<BlogDto> GetBlogByUserId(Guid userId, Guid blogId)
        {
            await CheckUser(userId);
            var blog = await _blogRepository.GetById(blogId);
            return blog.ParseToModel();
        }
        public async Task<List<BlogDto>> GetAllUserBlogs(Guid userId)
        {
            await CheckUser(userId);
            var blogs = await _blogRepository.GetAll();
            var relatedBlogs = blogs?.Where(b => b.UserId == userId).ToList();
            return relatedBlogs.ParseModels();
        }
        public async Task<BlogDto> AddBlog(Guid userId, CreateBlogModel model)
        {
            await CheckUser(userId);
            await IsExist(model.Name);
            Data.Entities.Blog blog = new()
            {
                Name = model.Name,
                Description = model.Description,
                UserId = userId,
            };
            await _blogRepository.Add(blog);
            return blog.ParseToModel();
        }
        public async Task<BlogDto> UpdateBlog(Guid userId, Guid blogId, UpdateBlogModel model)
        {
            var blog = await GetBlogById(userId, blogId);
            var check = false;
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                await IsExist(model.Name);
                blog.Name = model.Name;
                check = true;
            }
            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                blog.Description = model.Description;
                check = true;
            }
            if(check) await _blogRepository.Update(blog);
            return blog.ParseToModel();
        }
        public async Task<string> DeleteBlog(Guid userId,Guid blogId)
        {
            var blog = await GetBlogById(userId, blogId);
            await _blogRepository.Delete(blog);
            return "Deleted successfully";
        }

        private async Task<User> CheckUser(Guid userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user is null) throw new Exception("User not found");
            return user;
        }
        private async Task IsExist(string name)
        {
            var blog = await _blogRepository.GetByName(name);
            if (blog is not null) throw new Exception($"This name \"{name}\" already exist");
        }
        private async Task<Blog.Data.Entities.Blog> GetBlogById(Guid userId, Guid blogId)
        {
            var user = await CheckUser(userId);
            var blog = user.Blogs?.FirstOrDefault(b => b.Id == blogId);
            if (blog is null) throw new Exception($"Invalid blogId \"{blogId}\"");
            return blog;
        }
    }
}
