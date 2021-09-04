using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Lấy tất cả user
        /// </summary>
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
        [Authorize]
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
        [HttpGet("Role/{userId}")]
        public async Task<IActionResult> GetListRoles(int userId)
        {
            var user = await _userService.GeRole(userId);
            if (user == null)
                return BadRequest("Cannot find user");
            return Ok(user);
        }

        /// <summary>
        /// lấy ds user trả về theo định dạng UserViewModel
        /// </summary>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            if (users == null)
                return BadRequest("Cannot find user");
            return Ok(users);
        }



        /// <summary>
        /// lấy ds user trả về theo định dạng viewModelResult
        /// </summary>
        [HttpGet("allUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var userVM = await _userService.GetAllModel();
            if (userVM == null)
                return BadRequest("Cannot find user");
            return Ok(userVM);
        }

    }
}
