using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.SinhVienServices
{
    /// <summary>
    /// Các phương thức bảng sinh viên
    /// </summary>
    public interface ISinhVienService : IBaseService<SinhVien, SinhVienDTO>
    {
        Task<PagedResult<SinhVienDTO>> DanhSachSinhVien(string Tensv, Paging request);
        Task<SinhVienDTO> LaySinhVienTheoId(Guid Id);
        Task<SinhVien> ThemMoiSinhVien(SinhVienDTO request);
        Task<SinhVien> CapNhatSinhVien(Guid Id, SinhVienDTO request);
        Task<int> XoaSinhVien(Guid Id);
    }
}
