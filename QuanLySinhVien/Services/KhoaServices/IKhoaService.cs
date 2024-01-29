using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.KhoaDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.KhoaServices
{
    /// <summary>
    /// các phương thức bảng khoa
    /// </summary>
    public interface IKhoaService : IBaseService<Khoa, KhoaDTO>
    {
        Task<PagedResult<KhoaDTO>> DanhSachKhoa(Paging request);
        Task<KhoaDTO> LayKhoaTheoId(Guid Id);
        Task<Khoa> ThemMoiKhoa(KhoaDTO request);
        Task<Khoa> CapNhatKhoa(Guid Id, KhoaDTO request);
        Task<int> XoaKhoa(Guid Id);
    }
}
