using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.LopDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.LopServices;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopsController : ControllerBase
    {
        private readonly ILopService _lopService;
        public LopsController(ILopService lopService)
        {
            _lopService = lopService;
        }

        /// <summary>
        /// Phân trang lớp
        /// </summary>
        /// <param name="request">đối tượng cần phân trang</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        [HttpGet("paging")]
        public async Task<IActionResult> LayDanhSachLop([FromQuery] Paging request)
        {
            var lop = await _lopService.DanhSachLop(request);
            return Ok(lop);

        }


        /// <summary>
        /// Lấy lớp theo Id
        /// </summary>
        /// <param name="Id">Id lớp cần lấy</param>
        /// <returns>true: trả về thành công, false: trả về thất bại</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> LayLopTheoId(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var lops = await _lopService.LayLopTheoId(Id);
            if (lops == null)
                return NotFound("Không tìm thấy lớp");
            return Ok(lops);
        }

        /// <summary>
        /// Thêm mới lớp
        /// </summary>
        /// <param name="request">Đối tượng cần thêm mới</param>
        /// <returns>true: nếu thành công, false: nếu thất bại</returns>
        [HttpPost]
        public async Task<IActionResult> ThemMoiLop([FromForm] LopDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var lops = await _lopService.ThemMoiLop(request);
            if (lops == null)
                return NotFound("Không tìm thấy lớp");
            return Ok(lops);
        }

        /// <summary>
        /// Cập nhật lớp
        /// </summary>
        /// <param name="Id">Id lớp cần cập nhật</param>
        /// <param name="request">Đối tượng cần cập nhật</param>
        /// <returns>true: trả về thành công, false: trả về thất bại</returns>
        [HttpPut]
        public async Task<IActionResult> CapNhatLop(/*[FromRoute]*/ Guid Id,[FromForm] LopDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var lops = await _lopService.CapNhatLop(Id, request);
            if (lops == null)
                return NotFound("Không tìm thấy lớp");
            return Ok(lops);
        }

        /// <summary>
        /// Xóa lớp
        /// </summary>
        /// <param name="Id">Id lớp cần xóa</param>
        /// <returns>true: xoá thành công, false: xóa thất bại</returns>
        [HttpDelete]
        public async Task<IActionResult> XoaLop(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var lops = await _lopService.XoaLop(Id);
            if (lops == 0)
                return NotFound("Không tìm thấy lớp");
            return Ok();
        }
    }
}
