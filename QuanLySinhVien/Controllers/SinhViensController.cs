using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.SinhVienServices;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class SinhViensController : ControllerBase
    {
        private readonly ISinhVienService _sinhVienService;
        public SinhViensController(ISinhVienService sinhVienService)
        {
            _sinhVienService = sinhVienService;
        }

        /// <summary>
        /// Phân trang sinh viên
        /// </summary>
        /// <param name="request">đối tượng cần phân trang</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpGet("paging")]
        public async Task<IActionResult> LayDanhSachSinhVien(string Tensv, [FromQuery] Paging request)
        {
           var sinhVien = await _sinhVienService.DanhSachSinhVien(Tensv, request);
            return Ok(sinhVien);

        }
        /// <summary>
        /// Lây khách hàng theo Id
        /// </summary>
        /// <param name="Id">Id khách hàng</param>
        /// <returns>true: cập nhật thành công, false: cập nhật thất bại</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> LaySinhVienTheoId(Guid Id)
        {
            var sinhViens = await _sinhVienService.LaySinhVienTheoId(Id);
            if (sinhViens == null)
                return BadRequest("Không tìm thấy sinh viên ");
            return Ok(sinhViens);
        }

        /// <summary>
        /// Thêm mới sinh viên
        /// </summary>
        /// <param name="request">Đối tượng cần thêm mới</param>
        /// <returns>true: thêm mới thành công, false: cập nhật thất bại</returns>
        [HttpPost]
        public async Task<IActionResult> ThemMoiSinhVien(SinhVienDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var sinhViens = await _sinhVienService.ThemMoiSinhVien(request);
            return Ok(sinhViens);
        }

        /// <summary>
        /// Cập nhật sinh viên
        /// </summary>
        /// <param name="Id">Id sinh viên cần cập nhật</param>
        /// <param name="request">Cập nhật khách hàng theo đối tượng request</param>
        /// <returns>true: cập nhật thành công, false: cập nhật thất bại</returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> CapNhatSinhVien([FromRoute]Guid Id, [FromForm] SinhVienDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var sinhViens = await _sinhVienService.CapNhatSinhVien(Id, request);
            if (sinhViens == null)
                return NotFound("Không tìm thấy sinh viên!");
            return Ok(sinhViens);
        }


        /// <summary>
        /// Xóa sinh viên
        /// </summary>
        /// <param name="Id">Id sinh viên cần xóa</param>
        /// <returns>true : xóa sinh viên thành công, false: xóa sinh viên thất bại</returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> XoaSinhVien(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var sinhViens = await _sinhVienService.XoaSinhVien(Id);
            if (sinhViens == 0)
                return NotFound("Không tìm thấy mã sinh viên");
            return Ok();
        }
    }
}
