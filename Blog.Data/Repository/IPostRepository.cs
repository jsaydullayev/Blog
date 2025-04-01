using Blog.Data.Entities;

namespace Blog.Data.Repository;

public interface IPostRepository
{
    public Task<List<Post>> GetAll();
    public Task<Post> GetById(Guid id);
    public Task Add(Post post);
    public Task Update(Post post);
    public Task Delete(Post post);
}
