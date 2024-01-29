using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Context;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.QuyenNguoiDungServices
{
    public class RoleService : IRoleService
    {
        private readonly QLSVContext _qLSVContext;
        public RoleService(QLSVContext qLSVContext)
        {
            _qLSVContext = qLSVContext;
        }

        /// <summary>
		/// cap nhat quyen nguoi dung
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception"></exception>
        public async Task<AppRole> CapNhatQuyenNguoiDung(Guid Id, AppRole request)
        {
            var quyenNguoiDung = await _qLSVContext.AppRoles.FirstOrDefaultAsync(x => x.Id == Id);
            if (quyenNguoiDung == null)
            {
                throw new System.Exception($"Khong tim thay ma quyen nguoi dung: {Id}");
            }

            quyenNguoiDung.Descrip = request.Descrip;
            quyenNguoiDung.Name = request.Name;
            quyenNguoiDung.NormalizedName = request.NormalizedName;
            quyenNguoiDung.ConcurrencyStamp = request.ConcurrencyStamp;
            _qLSVContext.AppRoles.Update(quyenNguoiDung);

            await _qLSVContext.SaveChangesAsync();

            return quyenNguoiDung;
        }


        /// <summary>
		/// lay quyen nguoi dung theo id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception"></exception>
        public async Task<AppRole> LayQuyenNguoiDungTheoId(Guid Id)
        {
            var IdRoleUser = await _qLSVContext.AppRoles.FirstOrDefaultAsync(x => x.Id == Id);          
            if (IdRoleUser == null) throw new System.Exception($"Khong tim thay mot quyen nguoi dung theo {Id}");

            var quyenNguoiDung = new AppRole()
            {
                Id = IdRoleUser.Id,
                Descrip = IdRoleUser.Descrip,
                Name = IdRoleUser.Name,
                NormalizedName = IdRoleUser.NormalizedName,
                ConcurrencyStamp = IdRoleUser.ConcurrencyStamp,
            };
            return quyenNguoiDung;
        }

        /// <summary>
        /// them moi quyen nguoi dung
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AppRole> ThemMoiQuyenNguoiDung(AppRole request)
        {
            var quyenNguoiDung = new AppRole()
            {
                Id = Guid.NewGuid(),
                Descrip = request.Descrip,
                Name = request.Name,
                NormalizedName = request.NormalizedName,
                ConcurrencyStamp = request.ConcurrencyStamp,
            };

            _qLSVContext.AppRoles.Add(quyenNguoiDung);
            await _qLSVContext.SaveChangesAsync();
            return quyenNguoiDung;
        }

        /// <summary>
		/// xoa quyen nguoi dung
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception"></exception>
        public async Task<int> XoaQuyenNguoiDung(Guid Id)
        {
            var quyenNguoiDung = await _qLSVContext.AppRoles.FirstOrDefaultAsync(x => x.Id == Id);
            if (quyenNguoiDung == null)
                throw new System.Exception($"Khong tim thay Id cua quyen nguoi dung : {Id}");
            _qLSVContext.AppRoles.Remove(quyenNguoiDung);
            return await _qLSVContext.SaveChangesAsync();
        }
    }
}
