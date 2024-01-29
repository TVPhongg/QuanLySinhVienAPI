using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Context;
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
    public class KhoaService : BaseService<Khoa, KhoaDTO>, IKhoaService
    {
        private readonly QLSVContext _context;
        private readonly IMapper _mapper;

        public KhoaService(QLSVContext context, IMapper mapper)
            :base(mapper, context)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Cập nhật khoa
        /// </summary>
        /// <param name="Id">Id khoa cần cập nhật</param>
        /// <param name="request">đối tượng khoa cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<Khoa> CapNhatKhoa(Guid Id, KhoaDTO request)
        {
            return base.Update(Id, request);
        }

        /// <summary>
        /// lấy danh sách khoa(tìm kiếm, sắp xếp,phân trang,...)
        /// </summary>
        /// <param name="request">đối tượng cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public async Task<PagedResult<KhoaDTO>> DanhSachKhoa(Paging request)
        {
            #region query
            var query = _context.Khoas.Include(x => x.GiangViens).AsNoTracking();
            #endregion

            #region filtering
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.MaKhoa.Contains(request.Keyword));
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.TenKhoa.Contains(request.Keyword));
            #endregion

            #region sorting
            //Default sort by Name (Masv)
            query = query.OrderBy(k => k.MaKhoa);

            if (!string.IsNullOrEmpty(request.sortBy))
            {
                switch (request.sortBy)
                {
                    case "masv_desc": query = query.OrderByDescending(k => k.MaKhoa); break;
                    case "tensv_asc": query = query.OrderBy(k => k.TenKhoa); break;
                    case "tensv_desc": query = query.OrderByDescending(k => k.TenKhoa); break;
                }
            }

            #endregion

            #region paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new KhoaDTO()
                {
                   MaKhoa = x.MaKhoa,
                   TenKhoa = x.TenKhoa
                }).AsNoTracking().ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<KhoaDTO>()
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
        /// lấy danh sách khoa theo Id
        /// </summary>
        /// <param name="Id">Id khoa cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<KhoaDTO> LayKhoaTheoId(Guid Id)
        {
            return base.GetById(Id);
        }

        /// <summary>
        /// thêm mới khoa
        /// </summary>
        /// <param name="request">đối tượng khoa cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<Khoa> ThemMoiKhoa(KhoaDTO request)
        {
            return base.Create(request);
        }

        /// <summary>
        /// Xóa khoa
        /// </summary>
        /// <param name="Id">Id khoa cần xóa</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<int> XoaKhoa(Guid Id)
        {
            return base.Delete(Id); 
        }
    }
}
