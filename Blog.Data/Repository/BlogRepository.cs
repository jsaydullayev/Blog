using Blog.Data.Context;
using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _context;

    public BlogRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task Add(Entities.Blog blog)
    {
        _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Entities.Blog blog)
    {
        _context.Blogs.Remove(blog);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Entities.Blog>> GetAll() => await _context.Blogs.ToListAsync();

    public async Task<Entities.Blog> GetById(Guid id)
    {
        var blog = await _context.Blogs.FirstOrDefaultAsync(x => x.Id == id);
        if (blog is null) throw new Exception("Blog not Found");
        return blog;
    }

    public Task<Entities.Blog?> GetByName(string name)
    {
        return _context.Blogs.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task Update(Entities.Blog blog)
    {
        _context.Blogs.Update(blog);
        await _context.SaveChangesAsync();
    }
}
