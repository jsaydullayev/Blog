
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly ProjectContext _projectContext;
    public BlogRepository(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }
    public async Task Add(Entities.Blog blog)
    {
        _projectContext.Blogs.Add(blog);
        await _projectContext.SaveChangesAsync();
    }

    public async Task Delete(Entities.Blog blog)
    {
        _projectContext.Blogs.Remove(blog);
        await _projectContext.SaveChangesAsync();
    }


    public async Task<List<Entities.Blog>?> GetAll()
    {
        var blogs = await _projectContext.Blogs.ToListAsync();
        return blogs;
    }

    public async Task<Entities.Blog> GetById(int id)
    {
        var blog = await _projectContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
        if (blog is null) throw new Exception("Blog not found!");
        return blog;
    }

    public async Task<Entities.Blog> GetByName(string name)
    {
        var blog = await _projectContext.Blogs.FirstOrDefaultAsync(b => b.Name == name);
        if (blog is null) throw new Exception("Blog not found!");
        return blog;
    }

    public async Task Update(Entities.Blog blog)
    {
        _projectContext.Blogs.Update(blog);
        await _projectContext.SaveChangesAsync();
    }
}
