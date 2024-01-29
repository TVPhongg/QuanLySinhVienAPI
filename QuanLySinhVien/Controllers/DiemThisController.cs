using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.DiemThiDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.DiemThiServices;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemThisController : ControllerBase
    {
        private readonly IDiemThiService _diemThiService;
        public DiemThisController(IDiemThiService diemThiService)
        {
            _diemThiService = diemThiService;
        }
        /// <summary>
        /// Phân trang điểm thi
        /// </summary>
        /// <param name="request">đối tượng cần phân trang</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpGet("paging")]
        public async Task<IActionResult> LayDanhSachSinhVien([FromQuery] Paging request)
        {
            var diemThi = await _diemThiService.DanhSachDiemThi(request);
            return Ok(diemThi);

        }

        /// <summary>
        /// Lấy điểm thi theo Id
        /// </summary>
        /// <param name="Id">Id điểm thi cần lấy</param>
        /// <returns>true: trả về thành công, false: trả về thất bại</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> LayDiemThiTheoId(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var diemThis = await _diemThiService.LayDiemThiTheoId(Id);
            if (diemThis == null)
                return NotFound("Không tìm thấy điểm thi");
            return Ok(diemThis);
        }

        /// <summary>
        /// Thêm mới điểm thi
        /// </summary>
        /// <param name="request">Đối tượng cần thêm mới</param>
        /// <returns>trả về thành công, false: trả về thất bại</returns>
        [HttpPost]
        public async Task<IActionResult> ThemMoiDiemThi([FromForm] DiemThiDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var diemThis = await _diemThiService.ThemMoiDiemThi(request);
            if (diemThis == null)
                return NotFound("Không tìm thấy điểm thi");
            return Ok(diemThis);
        }

        /// <summary>
        /// cập nhật điểm thi
        /// </summary>
        /// <param name="Id">Id điểm thi cần cập nhật</param>
        /// <param name="request">Đối tượng cần cập nhật</param>
        /// <returns>trả về thành công, false: trả về thất bại</returns>
        [HttpPut]
        public async Task<IActionResult> CapNhatDiemThi(Guid Id, [FromForm] DiemThiDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var diemThis = await _diemThiService.CapNhatDiemThi(Id,request);
            if (diemThis == null)
                return NotFound("Không tìm thấy điểm thi");
            return Ok(diemThis);
        }

        /// <summary>
        /// Xóa điểm thi
        /// </summary>
        /// <param name="Id">Id điểm thi cần xóa</param>
        /// <returns>trả về thành công, false: trả về thất bại</returns>
        [HttpDelete]
        public async Task<IActionResult> XoaDiemThi(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var diemThis = await _diemThiService.XoaDiemThi(Id);
            if (diemThis == 0)
                return NotFound("Không tìm thấy điểm thi");
            return Ok();
        }
    }
}
