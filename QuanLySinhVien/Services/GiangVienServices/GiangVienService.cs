using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Context;
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
    public class GiangVienService : BaseService<GiangVien, GiangVienDTO>,  IGiangVienService
    {
        private readonly QLSVContext _context;
        private readonly IMapper _mapper;
        public GiangVienService(QLSVContext context, IMapper mapper)
            :base(mapper, context)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// cập nhật giảng viên
        /// </summary>
        /// <param name="Id">Id giảng viên cần cập nhật</param>
        /// <param name="request">đối tượng giảng viên cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<GiangVien> CapNhatGiangVien(Guid Id, GiangVienDTO request)
        {
            return base.Update(Id, request);
        }

        /// <summary>
        /// phân trang sinh viên
        /// </summary>
        /// <param name="request">đối tượng giảng viên cần phân trang </param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public async Task<PagedResult<GiangVienDTO>> DanhSachGiangVien(Paging request)
        {
            #region query
            var query = _context.GiangViens.Include(x => x.Khoa).AsNoTracking();
            #endregion

            #region filtering
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.MaGv.Contains(request.Keyword));
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.TenGv.Contains(request.Keyword));
            #endregion

            #region sorting
            //Default sort by Name (Masv)
            query = query.OrderBy(gv => gv.MaGv);

            if (!string.IsNullOrEmpty(request.sortBy))
            {
                switch (request.sortBy)
                {
                    case "masv_desc": query = query.OrderByDescending(gv => gv.MaGv); break;
                    case "tensv_asc": query = query.OrderBy(gv => gv.TenGv); break;
                    case "tensv_desc": query = query.OrderByDescending(gv => gv.TenGv); break;
                }
            }

            #endregion

            #region paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new GiangVienDTO()
                {
                   MaGv = x.MaGv,
                   TenGv = x.TenGv,
                   ChuyenNganh = x.ChuyenNganh
                }).AsNoTracking().ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<GiangVienDTO>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
            #endregion
        }

        /// <summary>
        /// Lấy giảng viên theo Id
        /// </summary>
        /// <param name="Id">Id giảng viên cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<GiangVienDTO> LayGiangVienTheoId(Guid Id)
        {
            return base.GetById(Id);
        }

        /// <summary>
        /// thêm mới giảng viên
        /// </summary>
        /// <param name="request">đối tượng giảng viên cần thêm mới</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<GiangVien> ThemMoiGiangVien(GiangVienDTO request)
        {
            return base.Create(request);
        }

        /// <summary>
        /// xóa giảng viên
        /// </summary>
        /// <param name="Id">Id giảng viên cần xóa</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<int> XoaGiangVien(Guid Id)
        {
            return base.Delete(Id); 
        }
    }
}
