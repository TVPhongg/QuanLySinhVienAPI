using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.UserDTOs;
using QuanLySinhVien.Services.NguoiDungServices;

namespace QuanLySinhVien.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.Register(request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.RegisterAdmin(request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _logger.LogInformation($"Đăng nhập lúc :{DateTime.Now} ");
            var result = await _userService.Login(request);
            if (string.IsNullOrEmpty(result.ObjectResult))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var changePassword = await _userService.ChangePassword(request);
            if (changePassword.IsSuccessed)
                return Ok("Đổi mật khẩu thành công");
            return BadRequest("Đổi mật khẩu thất bại");
        }

        [HttpPut("LockAndUnlock")]
        public async Task<IActionResult> LockandUnlock(LockUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (request.isLocked == true)
            {
                var LockandUnlock = await _userService.LockUser(request);
                if (LockandUnlock.IsSuccessed)
                    return Ok("Khóa tài khoản thành công");
                return BadRequest("Khóa tài khoản thất bại");

            }
            else
            {
                var LockandUnlock = await _userService.UnlockUser(request);
                if (LockandUnlock.IsSuccessed)
                    return Ok(" Mở khóa tài khoản thành công");
                return BadRequest(" Mở khóa tài khoản thất bại");
            }
        }
    }
}
