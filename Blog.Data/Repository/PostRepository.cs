using Blog.Data.Context;
using Blog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository;

public class PostRepository : IPostRepository
{
    private readonly ProjectContext _projectContext;
    public PostRepository(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }
    public async Task<List<Post>?> GetAll() => await _projectContext.Posts.ToListAsync();

    public async Task<Post?> GetById(int id)
    {
        var post = await _projectContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
        return post;
    }

    public async Task Update(Post post)
    {
        _projectContext.Posts.Update(post);
        await _projectContext.SaveChangesAsync();
    }

    async Task IPostRepository.Add(Post post)
    {
        _projectContext.Posts.Add(post);
        await _projectContext.SaveChangesAsync();
    }

    async Task IPostRepository.Delete(Post post)
    {
        _projectContext.Posts.Remove(post);
        await _projectContext.SaveChangesAsync();
    }
}
