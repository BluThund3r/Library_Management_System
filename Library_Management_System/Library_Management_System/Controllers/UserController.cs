using Library_Management_System.Models;
using Library_Management_System.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }


        [HttpGet("getAllUsersAsync")]
        public async Task<List<User>> GetAllAsync()
        {
            return await userService.GetAllUsersAsync();
        }
    }
}
