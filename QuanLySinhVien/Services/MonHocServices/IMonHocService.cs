using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.MonHocDTO;
using QuanLySinhVien.DTOs.MonHocDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.MonHocServices
{
    /// <summary>
    /// Các phương thức bảng môn học
    /// </summary>
    public interface IMonHocService : IBaseService<MonHoc, MonHocDTO>
    {
        Task<PagedResult<MonHocDTO>> DanhSachMonHoc(Paging request);
        Task<MonHocDTO> LayMonHocTheoId(Guid Id);
        Task<MonHoc> ThemMoiMonHoc(MonHocDTO request);
        Task<MonHoc> CapNhatMonHoc(Guid Id, MonHocDTO request);
        Task<int> XoaMonHoc(Guid Id);
    }
}
