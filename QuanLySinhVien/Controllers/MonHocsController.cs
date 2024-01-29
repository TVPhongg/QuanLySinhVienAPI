using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.MonHocDTO;
using QuanLySinhVien.DTOs.MonHocDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.MonHocServices;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocsController : ControllerBase
    {
        private readonly IMonHocService _monHocService;
        public MonHocsController(IMonHocService monHocService)
        {
            _monHocService = monHocService;
        }

        /// <summary>
        /// Phân trang môn học
        /// </summary>
        /// <param name="request">đối tượng cần phân trang</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpGet("paging")]
        public async Task<IActionResult> LayDanhSachMonHoc([FromQuery] Paging request)
        {
            var monHoc = await _monHocService.DanhSachMonHoc(request);
            return Ok(monHoc);

        }

        /// <summary>
        /// Lấy môn học theo Id
        /// </summary>
        /// <param name="Id">Id của môn học</param>
        /// <returns>true: nếu trẩ về thành công, false: trả về thất bại</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> LayMonHocTheoId(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var monHocs = await _monHocService.LayMonHocTheoId(Id);
            if (monHocs == null)
                return NotFound("Không tìm thấy môn học ");
            return Ok(monHocs);
        }

        /// <summary>
        /// Thêm mới môn học
        /// </summary>
        /// <param name="request">Đối tượng cần thêm</param>
        /// <returns>true: trả về thành công, false: trả về thất bại</returns>
        [HttpPost]
        public async Task<IActionResult> ThemMoiMonHoc([FromForm] MonHocDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var monHocs = await _monHocService.ThemMoiMonHoc(request);
            if (monHocs == null)
                return NotFound("Không tìm thấy môn học");
            return Ok(monHocs);
        }

        /// <summary>
        /// Cập nhật môn học
        /// </summary>
        /// <param name="Id">Id môn học cần lấy</param>
        /// <param name="request">Đối tượng cần cập nhật</param>
        /// <returns>true: trả về thành công, false: trả về thất bại</returns>
        [HttpPut]
        public async Task<IActionResult> CapNhatMonHoc(/*[FromRoute]*/Guid Id, [FromForm] MonHocDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var monHocs = await _monHocService.CapNhatMonHoc(Id, request);
            if (monHocs == null)
                return NotFound("Không tìm thấy môn học");
            return Ok(monHocs);
        }

        /// <summary>
        /// Xóa môn học
        /// </summary>
        /// <param name="Id">Id của môn học cần xóa</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> XoaMonHoc(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var monHocs = await _monHocService.XoaMonHoc(Id);
            if (monHocs == 0)
                return NotFound("Không tìm thấy môn học");
            return Ok();

        }
    }
}
