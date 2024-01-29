using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.LopDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.LopServices
{
    /// <summary>
    /// Các phương thức bảng lớp
    /// </summary>
    public interface ILopService : IBaseService<Lop, LopDTO>
    {
        Task<PagedResult<LopDTO>> DanhSachLop(Paging request);
        Task<LopDTO> LayLopTheoId(Guid Id);
        Task<Lop> ThemMoiLop(LopDTO request);
        Task<Lop> CapNhatLop(Guid Id, LopDTO request);
        Task<int> XoaLop(Guid Id);
    }
}
