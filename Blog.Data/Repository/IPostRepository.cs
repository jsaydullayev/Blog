namespace Blog.Data.Repository;

public interface IPostRepository
{
    public Task<List<Entities.Post>?> GetAll();
    public Task<Entities.Post?> GetById(int id);
    public Task Add(Entities.Post post);
    public Task Update(Entities.Post post);
    public Task Delete(Entities.Post post);
}
