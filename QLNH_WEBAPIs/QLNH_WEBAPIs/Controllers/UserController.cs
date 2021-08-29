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
        /// Thêm User mới
        /// </summary>
        /// <returns>User</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserCreateRequest request)
        {
            var userId = await _userService.Create(request);

            return Ok();
        }

        /// <summary>
        /// Cập nhật User mới
        /// </summary>
        /// <returns>User</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UserUpdateRequest request)
        {
            var affectedResult = await _userService.Update(request);

            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }

        /// <summary>
        /// Get user theo ID
        /// </summary>
        /// <returns>User</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null)
                return BadRequest("Cannot find user");
            return Ok(user);
        }


        /// <summary>
        /// Cập nhật Username
        /// </summary>
        /// <returns>User</returns>
        [HttpPut("{userId}/{newUserName}")]
        public async Task<IActionResult> UpdateUserName(int userId, string newUserName)
        {
            var isSuccessful = await _userService.updateUserName(userId, newUserName);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }


        /// <summary>
        /// Cập nhật Password
        /// </summary>
        /// <returns>User</returns>
        [HttpPut("{userId}/{newPassword}")]
        public async Task<IActionResult> UpdatePassword(int userId, string newPassword)
        {
            var isSuccessful = await _userService.updatePassword(userId, newPassword);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }


        /// <summary>
        /// Cập nhật Description
        /// </summary>
        /// <returns>User</returns>
        [HttpPut("{userId}/{newDescription}")]
        public async Task<IActionResult> UpdateDescription(int userId, string newDescription)
        {
            var isSuccessful = await _userService.updateDescription(userId, newDescription);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Xóa user theo ID
        /// </summary>
        /// <returns>User</returns>

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var affectedResult = await _userService.Delete(userId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        /// <summary>
        /// Get Role user theo ID
        /// </summary>
        /// <returns>User</returns>
        [HttpGet("Role/{userId}")]
        public async Task<IActionResult> GetListRoles(int userId)
        {
            var user = await _userService.GeRole(userId);
            if (user == null)
                return BadRequest("Cannot find user");
            return Ok(user);
        }

    }
}
