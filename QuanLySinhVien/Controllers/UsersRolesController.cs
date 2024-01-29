using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Services.QuyenNguoiDungServices;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersRolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public UsersRolesController(IRoleService roleService)
        {
                _roleService = roleService;
        }

        [HttpGet("userRole")]
        public async Task<IActionResult> LayQuyenNguoiDungTheoId(Guid Id)
        {
            var userRole = await _roleService.LayQuyenNguoiDungTheoId(Id);
            return Ok(userRole);
        }

        [HttpPost]
        public async Task<IActionResult> ThemMoiQuyenNguoiDung(AppRole request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userRole = await _roleService.ThemMoiQuyenNguoiDung(request);
            return Ok(userRole);
        }
        [HttpPut]
        public async Task<IActionResult> CapNhatQuyenNguoiDung(Guid Id, AppRole request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userRole = await _roleService.CapNhatQuyenNguoiDung(Id, request);           
            return Ok(userRole);
        }
        [HttpDelete]
        public async Task<IActionResult> XoaQuyenNguoiDung(Guid Id)
        {
            var userRole = await _roleService.XoaQuyenNguoiDung(Id);
            return Ok();
        }
    }
}
