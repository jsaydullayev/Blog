namespace Blog.Data.Repository;

public interface IPostRepository
{
    public Task<List<Entities.Post>?> GetAll();
    public Task<Entities.Post> GetById(int id);
    public Task<Entities.Post> Add(Entities.Post post);
    public Task<Entities.Post> Update(Entities.Post post);
    public Task<Entities.Post> DeleteById(int id);
}
