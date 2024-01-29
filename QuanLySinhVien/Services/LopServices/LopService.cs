using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Context;
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
    public class LopService : BaseService<Lop, LopDTO>, ILopService
    {
        private readonly QLSVContext _context;
        private readonly IMapper _mapper;

        public LopService(QLSVContext context, IMapper mapper)
            :base(mapper, context)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// cập nhật lớp
        /// </summary>
        /// <param name="Id">Id lớp cần cập nhật </param>
        /// <param name="request">đối tượng cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<Lop> CapNhatLop(Guid Id, LopDTO request)
        {
            return base.Update(Id, request);    
        }

        /// <summary>
        /// Lấy danh sách lớp
        /// </summary>
        /// <param name="request">Đối tượng lớp cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public async Task<PagedResult<LopDTO>> DanhSachLop(Paging request)
        {
           
                #region query
                var query = _context.Lops.Include(x => x.Khoa).AsNoTracking();
                #endregion

                #region filtering
                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.MaLop.Contains(request.Keyword));
                if (!string.IsNullOrEmpty(request.Keyword))
                    query = query.Where(x => x.TenLop.Contains(request.Keyword));
                #endregion

                #region sorting
                //Default sort by Name (Masv)
                query = query.OrderBy(l => l.MaLop);

                if (!string.IsNullOrEmpty(request.sortBy))
                {
                    switch (request.sortBy)
                    {
                        case "masv_desc": query = query.OrderByDescending(l => l.MaLop); break;
                        case "tensv_asc": query = query.OrderBy(l => l.TenLop); break;
                        case "tensv_desc": query = query.OrderByDescending(l => l.TenLop); break;
                    }
                }

                #endregion

                #region paging
                int totalRow = await query.CountAsync();

                var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .Select(x => new LopDTO()
                    {
                       MaLop = x.MaLop,
                       TenLop = x.TenLop,
                    }).AsNoTracking().ToListAsync();

                //4. Select and projection
                var pagedResult = new PagedResult<LopDTO>()
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
        /// Lấy lớp học theo Id
        /// </summary>
        /// <param name="Id">Id mã lớp</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<LopDTO> LayLopTheoId(Guid Id)
        {
            return base.GetById(Id);
        }

        /// <summary>
        /// Thêm mới lớp học
        /// </summary>
        /// <param name="request">đối tượng cần thêm mới</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<Lop> ThemMoiLop(LopDTO request)
        {
           return base.Create(request);
        }

        /// <summary>
        /// xóa lớp học
        /// </summary>
        /// <param name="Id">Id lớp học cần xóa</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<int> XoaLop(Guid Id)
        {return base.Delete(Id);
        }
    }
}
