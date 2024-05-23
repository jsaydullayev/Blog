using Blog.Common.Dtos;
using Blog.Common.Models.User;
using Blog.Data;
using Blog.Data.Repository;
using Blog.Service.Extensions;
using Microsoft.AspNetCore.Identity;
namespace Blog.Service.Api;
public class UserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<List<UserDto>> GetAllUsers()
    {
        var users = await _userRepository.GetAll();
        return users.ParseModels();
    }
    public async Task<UserDto> GetUserById(Guid Id)
    {
        var user = await _userRepository.GetById(Id);
        return user.ParseToModel();
    }
    public async Task<UserDto> AddUser(CreateUserModel model)
    {
        await isExist(model.UserName);
        var user = new User()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.UserName
        };
        var passwordhash = new PasswordHasher<User>().HashPassword(user, model.Password);
        user.PasswordHash = passwordhash;
        await _userRepository.Add(user);
        return user.ParseToModel();
    }
    public async Task<UserDto> UpdateUser(Guid userId, UpdateUserModel model)
    {
        var user = await _userRepository.GetById(userId);
        if (!string.IsNullOrWhiteSpace(model.FirstName))
            user.FirstName = model.FirstName;
        if (!string.IsNullOrWhiteSpace(model.LastName))
            user.LastName = model.LastName;
        if (!string.IsNullOrWhiteSpace(model.UserName))
        {
            await isExist(model.UserName);
            user.Username = model.UserName;
        }
        await _userRepository.Update(user);
        return user.ParseToModel();
    }
    public async Task<string> DeleteUser(Guid userId)
    {
        var user = await _userRepository.GetById(userId);
        await _userRepository.Delete(user);
        return "User successfully deleted";
    }
    private async Task isExist(string username)
    {
        var isExist = await _userRepository.GetByUserName(username);
        if (isExist != null)
        {
            throw new Exception($"User already exists with this \"{username}\"");
        }
    }
}
