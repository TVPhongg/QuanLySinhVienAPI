using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Context;
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
    public class MonHocService : BaseService<MonHoc, MonHocDTO>,  IMonHocService
    {
        private readonly QLSVContext _context;
        private readonly IMapper _mapper;
        public MonHocService(QLSVContext context, IMapper mapper) : base(mapper, context)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// cập nhật môn học theo Id
        /// </summary>
        /// <param name="Id">Id môn học cần cập nhật</param>
        /// <param name="request">đối tượng cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<MonHoc> CapNhatMonHoc(Guid Id, MonHocDTO request)
        {
           return base.Update(Id, request);

        }

        /// <summary>
        /// lấy danh sách môn học(tìm kiếm, sắp xếp)
        /// </summary>
        /// <param name="request">Đối tượng cần lấy danh sách</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public async Task<PagedResult<MonHocDTO>> DanhSachMonHoc(Paging request)
        {
            #region query
            var query = _context.MonHocs.Include(x => x.DiemThis).AsNoTracking();
            #endregion

            #region filtering
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.MaMh.Contains(request.Keyword));
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.TenMh.Contains(request.Keyword));
            #endregion

            #region sorting
            //Default sort by Name (Masv)
            query = query.OrderBy(mh => mh.MaMh);

            if (!string.IsNullOrEmpty(request.sortBy))
            {
                switch (request.sortBy)
                {
                    case "masv_desc": query = query.OrderByDescending(mh => mh.MaMh); break;
                    case "tensv_asc": query = query.OrderBy(mh => mh.TenMh); break;
                    case "tensv_desc": query = query.OrderByDescending(mh => mh.TenMh); break;
                }
            }

            #endregion

            #region paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new MonHocDTO()
                {
                   MaMh = x.MaMh,
                   TenMh = x.TenMh,
                   SoGio = x.SoGio

                }).AsNoTracking().ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<MonHocDTO>()
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
        /// Lấy môn học theo Id
        /// </summary>
        /// <param name="Id">Id môn học cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<MonHocDTO> LayMonHocTheoId(Guid Id)
        {
            return base.GetById(Id);
        }

        /// <summary>
        /// thêm mới môn học
        /// </summary>
        /// <param name="request">đối tượng cần thêm mới</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<MonHoc> ThemMoiMonHoc(MonHocDTO request)
        {
            return base.Create(request);
        }

        /// <summary>
        /// Xóa môn học
        /// </summary>
        /// <param name="Id">Id môn học cần xóa</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<int> XoaMonHoc(Guid Id)
        {
            return base.Delete(Id);
        }
    }
}
