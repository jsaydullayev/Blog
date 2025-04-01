using Blog.Common.Dtos;
using Blog.Common.Models.Post;
using Blog.Data;
using Blog.Data.Entities;
using Blog.Data.Repository;
using Blog.Service.Extensions;
using System.Runtime.InteropServices;

namespace Blog.Service.Api;
public class PostService
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBlogRepository _blogRepository;
    public PostService(IPostRepository postRepository,IUserRepository userRepository, IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }
    public async Task<List<PostDto>> GetAllPosts()
    {
        var allPosts = await _postRepository.GetAll();
        if(allPosts is null)
            throw new Exception("No post found");
        return allPosts.ParseModels();
    }
    public async Task<PostDto> GetPostById(Guid postId)
    {
        var posts = await _postRepository.GetAll();
        var post = posts?.FirstOrDefault(p => p.Id == postId);
        if (post is null) throw new Exception($"The post is not found with\"{postId}\"");
        return post.ParseToModel();
    }
    public async Task<List<PostDto>> GetAllPosts(Guid userId, Guid blogId)
    {
        var posts = await FilteredPosts(userId,blogId);
        if(posts is null)
            throw new Exception("No post found");
        return posts.ParseModels();
    }
    public async Task<PostDto> GetPostById(Guid userId,Guid blogId,Guid postId)
    {
        var post = await CheckPost(userId, blogId, postId);
        return post.ParseToModel();
    }
    public async Task<PostDto> AddPost(Guid userId, Guid blogId,CreatePostModel model)
    {
        var user = await CheckUser(userId);
        await CheckBlog(userId, blogId);
        var post = new Post()
        {
            Title = model.Title,
            Content = model.Content,
            AuthorFullName = $"{user.FirstName} {user.LastName}",
            BlogId = blogId,
        };
        await _postRepository.Add(post);
        return post.ParseToModel();
    }
    public async Task<PostDto> UpdatePost(Guid userId, Guid blogId, Guid postId, UpdatePostModel model) 
    {
        var post = await CheckPost(userId,blogId,postId);
        var check = false;
        if (!string.IsNullOrWhiteSpace(model.Title))
        {
            post.Title = model.Title;
            check = true;
        }
        if (!string.IsNullOrWhiteSpace(model.Content))
        {
            post.Content = model.Content;
            check = true;
        }
        if(check)
            await _postRepository.Update(post);
        return post.ParseToModel();
    }
    public async Task<string> DeletePost(Guid userId, Guid blogId,Guid postId)
    {
        var post = await CheckPost(userId, blogId, postId);
        await _postRepository.Delete(post);
        return "Deleted successfully";
    }

    public async Task<List<PostDto>> GetBlogPosts(Guid userId, Guid blogId)
    {
        var posts = await FilteredPosts(userId,blogId);
        if(posts is null)
            throw new Exception("No post found");
        return posts.ParseModels();
    }

    private async Task<List<Post>?> FilteredPosts(Guid userId,Guid blogId)
    {
        var blog = await CheckBlog(userId,blogId);
        var filteredpost = blog.Posts?.Where(post => post.Id == blogId).ToList();
        return filteredpost;
    }
    private async Task<User> CheckUser(Guid userId)
    {
        var user = await _userRepository.GetById(userId);
        if(user is null)
            throw new Exception("User not found");
        return user;
    } 
    private async Task<Data.Entities.Blog> CheckBlog(Guid userId, Guid blogId)
    {
        var user = await CheckUser(userId);
        var blog = user.Blogs?.FirstOrDefault(blog => blog.Id == blogId);
        if (blog is null) throw new Exception($"Not found blog with \"{blogId}\"");
        return blog;
    }
    private async Task<Post> CheckPost(Guid userId,Guid blogId,Guid postId)
    {
        var blog = await CheckBlog(userId,blogId);
        var post = blog.Posts?.FirstOrDefault(post => post.Id == postId);
        if (post is null) throw new Exception($"Not found blog with \"{postId}\"");
        return post;
    }
}
