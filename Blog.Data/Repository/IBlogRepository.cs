namespace Blog.Data.Repository;

public interface IBlogRepository
{
    public Task<List<Entities.Blog>?> GetAll();
    public Task<Entities.Blog> GetById(int id);
    public Task<Entities.Blog> GetByName(string name);
    public Task<Entities.Blog> Add(Entities.Blog blog);
    public Task<Entities.Blog> Update(Entities.Blog blog);
    public Task<Entities.Blog> DeleteById(int id);
}
