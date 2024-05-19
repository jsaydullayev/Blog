using Blog.Data.Entities;

namespace Blog.Data.Repository;

public class PostRepository : IPostRepository
{
    public Task<Post> Add(Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Post> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Post>?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> Update(Post post)
    {
        throw new NotImplementedException();
    }
}
