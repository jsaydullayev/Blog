
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly ProjectContext _projectContext;

    public UserRepository(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public async Task Add(User user)
    {
        _projectContext.Users.Add(user);
        await _projectContext.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _projectContext.Users.Remove(user);
        await _projectContext.SaveChangesAsync();
    }

    public Task<List<User>?> GetAll() => _projectContext.Users.ToListAsync();

    public Task<User> GetById(Guid id)
    {
        var user = _projectContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user is null) throw new Exception("User not Found");
        return user;
    }

    public Task<User?> GetByUserName(string username)
    {
        var user = _projectContext.Users.FirstOrDefaultAsync(c => c.Username == username);
        if (user is null) throw new Exception("User not found");
        return user;
    }

    public async Task Update(User user)
    {
        _projectContext.Users.Update(user);
        await _projectContext.SaveChangesAsync();
    }
}
