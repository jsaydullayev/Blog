using Blog.Data.Context;
using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository;

public class PostRepository : IPostRepository
{
    private readonly BlogDbContext _context;

    public PostRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task Add(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Post post)
    {
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Post>> GetAll() => await _context.Posts.ToListAsync();

    public async Task<Post> GetById(Guid id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        if (post is null) throw new Exception("Post not Found");
        return post;
    }

    public async Task Update(Post post)
    {
        _context.Posts.Update(post);
        await _context.SaveChangesAsync();
    }
}
