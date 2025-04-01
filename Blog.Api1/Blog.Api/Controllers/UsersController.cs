using Blog.Common.Dtos;
using Blog.Common.Models.User;
using Blog.Service.Api;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers() 
        {
            var users = await _userService.GetAllUsers();
            return Ok(users.ToList());
        }

        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserModel createUserDto)
        {
            var createdUser = await _userService.AddUser(createUserDto);
            return Ok(createdUser);
        }

        [HttpPut("{userId:guid}")]
        public async Task<ActionResult<UserDto>> UpdateUser(Guid userId, UpdateUserModel updateUserDto)
        {
            var updatedUser = await _userService.UpdateUser(userId, updateUserDto);
            return Ok(updatedUser);
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await _userService.DeleteUser(userId);
            return Ok(result);
        }
    }
}
