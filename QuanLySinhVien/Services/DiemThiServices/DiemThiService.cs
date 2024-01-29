using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Context;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.DiemThiDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.DiemThiServices
{
    public class DiemThiService : BaseService<DiemThi, DiemThiDTO>, IDiemThiService
    {
        private readonly QLSVContext _context;
        private readonly IMapper _mapper;

        public DiemThiService(QLSVContext context, IMapper mapper)
            :base(mapper, context)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// cập nhật điểm thi
        /// </summary>
        /// <param name="Id">Id điểm thi cần cập nhật</param>
        /// <param name="request">đối tượng cần cập nhật</param>
        /// <returns></returns>
        public Task<DiemThi> CapNhatDiemThi(Guid Id, DiemThiDTO request)
        {
            return base.Update(Id, request);
        }

        /// <summary>
        /// phân trang 
        /// </summary>
        /// <param name="request">đối tượng điểm thi cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public async Task<PagedResult<DiemThiDTO>> DanhSachDiemThi(Paging request)
        {
            #region query
            var query = _context.DiemThis.Include(x => x.SinhVien).AsNoTracking();
            #endregion

            #region filtering
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.MaSv.ToString().Contains(request.Keyword));
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.MaMh.ToString().Contains(request.Keyword));
            #endregion

            #region sorting
            //Default sort by Name (Masv)
            query = query.OrderBy(sv => sv.MaSv);

            if (!string.IsNullOrEmpty(request.sortBy))
            {
                switch (request.sortBy)
                {
                    case "masv_desc": query = query.OrderByDescending(sv => sv.MaSv); break;
                    case "tensv_asc": query = query.OrderBy(mh => mh.MaMh); break;
                    case "tensv_desc": query = query.OrderByDescending(mh => mh.MaMh); break;
                }
            }

            #endregion

            #region paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DiemThiDTO()
                {
                    MaSv = x.MaSv,
                    MaMh = x.MaMh,
                    LanThi = x.LanThi,
                    Diem = x.Diem
                    
                }).AsNoTracking().ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<DiemThiDTO>()
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
        /// lấy điểm thi theo Id
        /// </summary>
        /// <param name="Id">Id điểm thi cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<DiemThiDTO> LayDiemThiTheoId(Guid Id)
        {
            return base.GetById(Id);
        }

        /// <summary>
        /// thêm mới điểm thi
        /// </summary>
        /// <param name="request">đối tượng điểm thi cần thêm mới</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<DiemThi> ThemMoiDiemThi(DiemThiDTO request)
        {
            return base.Create(request);
        }

        /// <summary>
        /// xóa điểm thi
        /// </summary>
        /// <param name="Id">Id điểm thi cần xóa</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<int> XoaDiemThi(Guid Id)
        {
            return base.Delete(Id); 

        }
    }
}
