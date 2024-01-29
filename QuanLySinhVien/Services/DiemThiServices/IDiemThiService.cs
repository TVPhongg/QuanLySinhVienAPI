using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.DiemThiDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.DiemThiServices
{
    /// <summary>
    /// Các phương thức bảng điểm thi
    /// </summary>
    public interface IDiemThiService : IBaseService<DiemThi, DiemThiDTO>
    {
        Task<PagedResult<DiemThiDTO>> DanhSachDiemThi(Paging request);
        Task<DiemThiDTO> LayDiemThiTheoId(Guid Id);
        Task<DiemThi> ThemMoiDiemThi(DiemThiDTO request);
        Task<DiemThi> CapNhatDiemThi(Guid Id, DiemThiDTO request);
        Task<int> XoaDiemThi(Guid Id);
    }
}
