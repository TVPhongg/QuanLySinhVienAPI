using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.GiangVienDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.GiangVienServices;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangViensController : ControllerBase
    {
        private readonly IGiangVienService _giangVienService;
        public GiangViensController(IGiangVienService giangVienService)
        {
            _giangVienService = giangVienService;
        }

        /// <summary>
        /// Phân trang giảng viên
        /// </summary>
        /// <param name="request">đối tượng cần phân trang</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpGet("paging")]
        public async Task<IActionResult> LayDanhSachGiangVien([FromQuery] Paging request)
        {
            var giangVien = await _giangVienService.DanhSachGiangVien(request);
            return Ok(giangVien);

        }
        /// <summary>
        /// Lấy giảng viên theo Id
        /// </summary>
        /// <param name="Id">Id giảng viên cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> LayGiangVienTheoId(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var giangViens = await _giangVienService.LayGiangVienTheoId(Id);
            if (giangViens == null)
                return NotFound("Không tìm thấy giảng viên");
            return Ok(giangViens);
        }

        /// <summary>
        /// Thêm mới giảng viên
        /// </summary>
        /// <param name="request">Đối tượng cần thêm mới</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpPost]
        public async Task<IActionResult> ThemMoiGiangVien([FromForm] GiangVienDTO request)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var giangViens = await _giangVienService.ThemMoiGiangVien(request);
            if (giangViens == null)
                return NotFound("Không tìm thấy giảng viên");
            return Ok(giangViens);
        }

        /// <summary>
        /// cập nhật giảng viên
        /// </summary>
        /// <param name="Id">Id giảng viên cần cập nhật</param>
        /// <param name="request">Đối tượng cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, flase: trả về thất bại</returns>
        [HttpPut]
        public async Task<IActionResult> CapNhatGiangVien(Guid Id, [FromForm] GiangVienDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var giangViens = await _giangVienService.CapNhatGiangVien(Id, request);
            if (giangViens == null)
                return NotFound("Không tìm thấy giảng viên");
            return Ok(giangViens);
        }

        /// <summary>
        /// xóa giảng viên
        /// </summary>
        /// <param name="Id">Id giảng viên cần xóa</param>
        /// <returns>true: nếu trả về thành công, flase: trả về thất bại</returns>
        [HttpDelete]
        public async Task<IActionResult> XoaGiangVien(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var giangViens = await _giangVienService.XoaGiangVien(Id);
            if (giangViens == 0)
                return NotFound("Không tìm thấy giảng viên");
            return Ok();
        }
    }
}
