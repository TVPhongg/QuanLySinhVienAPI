using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.KhoaDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.KhoaServices;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoasController : ControllerBase
    {
        private readonly IKhoaService _khoaService;
        public KhoasController(IKhoaService khoaService)
        {
            _khoaService = khoaService;
        }

        /// <summary>
        /// Phân trang khoa
        /// </summary>
        /// <param name="request">đối tượng cần phân trang</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpGet("paging")]
        public async Task<IActionResult> LayDanhSachKhoa([FromQuery] Paging request)
        {
            var khoa = await _khoaService.DanhSachKhoa(request);
            return Ok(khoa);

        }
        /// <summary>
        /// Lấy khoa theo Id
        /// </summary>
        /// <param name="Id">Id mã khoa cần lấy</param>
        /// <returns>true: trả về thành công, false: trả về thất bại</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> LayKhoaTheoId(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var khoa = await _khoaService.LayKhoaTheoId(Id);
            if (khoa == null)
                return NotFound("Không tìm thấy khoa");
            return Ok(khoa);
        }

        /// <summary>
        /// Thêm mới khoa
        /// </summary>
        /// <param name="request">đối tượng cần lấy </param>
        /// <returns>true: trả về thành công, false: trả về thất bại</returns>
        [HttpPost]
        public async Task<IActionResult> ThemMoiKhoa([FromForm] KhoaDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var khoa = await _khoaService.ThemMoiKhoa(request);
            if (khoa == null)
                return NotFound("Không tìm thấy khoa");
            return Ok(khoa);
        }

        /// <summary>
        /// Cập nhật khoa theo Id
        /// </summary>
        /// <param name="Id">Id khoa cần cập nhật</param
        /// <param name="request">Đối tượng cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: trả về thất bại</returns>
        [HttpPut]
        public async Task<IActionResult> CapNhatKhoa(/*[FromRoute]*/ Guid Id,[FromForm] KhoaDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var khoa = await _khoaService.CapNhatKhoa(Id, request);
            if (khoa == null)
                return NotFound("Không tìm thấy khoa");
            return Ok(khoa);
        }

        /// <summary>
        /// Xóa khoa theo Id
        /// </summary>
        /// <param name="Id">Id khoa cẫn xóa</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpDelete]
        public async Task<IActionResult> XoaKhoa(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var khoa = await _khoaService.XoaKhoa(Id);
            if (khoa == 0)
                return NotFound("Không tìm thấy khoa");
            return Ok();
        }
    }
}
