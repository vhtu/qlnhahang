using Microsoft.AspNetCore.Mvc;
using QLNH_WEBAPIs.DTOs.User;
using QLNH_WEBAPIs.Models;
using QLNH_WEBAPIs.Services.Users;
using System.Threading.Tasks;

namespace QLNH_WEBAPIs.Controllers
{
    /// <summary>
    /// API liên quan đến User
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        /// <summary>
        /// Thêm Role mới
        /// </summary>
        /// <returns>Role</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserCreateRequest request)
        {
            var userId = await _userService.Create(request);

            return Ok();
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null)
                return BadRequest("Cannot find user");
            return Ok(user);
        }

    }
}
