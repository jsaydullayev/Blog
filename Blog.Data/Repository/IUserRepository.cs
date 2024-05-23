namespace Blog.Data.Repository;

public interface IUserRepository
{
    public Task<List<User>?> GetAll();
    public Task<User?> GetById(Guid id);
    public Task<User?> GetByUserName(string username);
    public Task Add(User user);
    public Task Update(User user);
    public Task Delete(User user);
}
