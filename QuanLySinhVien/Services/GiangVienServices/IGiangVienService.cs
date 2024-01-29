using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.GiangVienDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.GiangVienServices
{

    /// <summary>
    /// Các phương thức bảng giảng viên
    /// </summary>
    public interface IGiangVienService : IBaseService<GiangVien, GiangVienDTO>
    {
        Task<PagedResult<GiangVienDTO>> DanhSachGiangVien(Paging request);
        Task<GiangVienDTO> LayGiangVienTheoId(Guid Id);
        Task<GiangVien> ThemMoiGiangVien(GiangVienDTO request);
        Task<GiangVien> CapNhatGiangVien(Guid Id, GiangVienDTO request);
        Task<int> XoaGiangVien(Guid Id);
    }
}
