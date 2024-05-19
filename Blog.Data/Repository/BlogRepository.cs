
namespace Blog.Data.Repository;

public class BlogRepository : IBlogRepository
{
    public Task<Entities.Blog> Add(Entities.Blog blog)
    {
        throw new NotImplementedException();
    }

    public Task<Entities.Blog> DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Entities.Blog>?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Entities.Blog> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Entities.Blog> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Entities.Blog> Update(Entities.Blog blog)
    {
        throw new NotImplementedException();
    }
}
