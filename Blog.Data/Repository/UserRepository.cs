
namespace Blog.Data.Repository;

public class UserRepository : IUserRepository
{
    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task Delete(User user)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUserName(string username)
    {
        throw new NotImplementedException();
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }
}
