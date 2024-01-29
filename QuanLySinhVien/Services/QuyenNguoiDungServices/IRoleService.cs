using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.QuyenNguoiDungServices
{
    public interface IRoleService
    {
        Task<AppRole> LayQuyenNguoiDungTheoId(Guid Id);
        Task<AppRole> ThemMoiQuyenNguoiDung(AppRole request);
        Task<AppRole> CapNhatQuyenNguoiDung(Guid Id, AppRole request);
        Task<int> XoaQuyenNguoiDung(Guid Id);
    }
}
