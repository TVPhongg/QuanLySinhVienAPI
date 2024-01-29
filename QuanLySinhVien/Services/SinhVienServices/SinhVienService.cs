using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Context;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.Common;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.SinhVienServices
{
    public class SinhVienService : BaseService<SinhVien, SinhVienDTO>, ISinhVienService
    {

        private readonly QLSVContext _context;
        private readonly IMapper _mapper;

        public SinhVienService(QLSVContext context,
            IMapper mapper
             ) : base(mapper, context)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Cập nhật sinh viên
        /// </summary>
        /// <param name="Id">Id sinh viên cần cập nhật</param>
        /// <param name="request">đối tượng sinh viên cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<SinhVien> CapNhatSinhVien(Guid Id, SinhVienDTO request)
        {
            return base.Update(Id, request);
        }

        /// <summary>
        /// Lấy danh sách sinh viên theo Id
        /// </summary>
        /// <param name="Id">Id sinh viên cần lấy</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>
        public Task<SinhVienDTO> LaySinhVienTheoId(Guid Id)
        {
            return base.GetById(Id);
        }

        /// <summary>
        /// thêm mới sinh viên
        /// </summary>
        /// <param name="request">đối tượng sinh viên cần cập nhật</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<SinhVien> ThemMoiSinhVien(SinhVienDTO request)
        {

            return base.Create(request);
        }

        /// <summary>
        /// xóa sinh viên
        /// </summary>
        /// <param name="Id">ID sinh viên cần xóa</param>
        /// <returns>true: nếu trả về thành công, false: nếu trả về thất bại</returns>

        public Task<int> XoaSinhVien(Guid Id)
        {
            return base.Delete(Id);
        }


        /// <summary>
        /// Lấy danh sách sinh viên(tìm kiếm , sắp xếp, ...)
        /// </summary>
        /// <param name="request">đối tượng sinh viên cần tìm kiếm</param>
        /// <returns></returns>
        public async Task<PagedResult<SinhVienDTO>> DanhSachSinhVien(string Tensv,  Paging request)
        {
            #region query
            //C1: cú pháp phương thức
            //var query = _context.SinhViens.Include(qr => qr.Lop).AsNoTracking();
            var query = _context.SinhViens.AsNoTracking();


            /* 
            C2 : cú pháp truy vấnlinq( Linq to Entities)
            var query = from sv in _context.SinhViens
                         select new { sv }; 
            */
            #endregion

            #region filtering
            // Nên tìm kiếm các keyword trong cùng 1 câu query(không nên sử dụng nhiều câu lệnh if)
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.MaSv.Contains(request.Keyword)
                || x.TenSv.Contains(request.Keyword));

            //if (!string.IsNullOrEmpty(request.Keyword))
            //{
            //    query = query.Where(x => x.MaSv.Contains(request.Keyword));
            //}

            if (!string.IsNullOrEmpty(Tensv))
            {
                query = query.Where(x => EF.Functions.FreeText(x.TenSv, Tensv));
            }
            #endregion
            int totalRow = await query.CountAsync();
            #region sorting
            //C1: sắp xếp sử dụng truy vấn sql trong EF
            //Default sort by Name(Masv)
            //query = query.OrderBy(sv => sv.MaSv);

            if (!string.IsNullOrEmpty(request.sortBy))
            {
                switch (request.sortBy)
                {
                    case "masv_asc": query = query.OrderBy(sv => sv.MaSv); break;
                    case "masv_desc": query = query.OrderByDescending(sv => sv.MaSv); break;
                    case "tensv_asc": query = query.OrderBy(sv => sv.TenSv); break;
                    case "tensv_desc": query = query.OrderByDescending(sv => sv.TenSv); break;
                }
            }


            //C2: 
            //query = query.OrderBy(x => x.sv.MaSv);

            //if (!string.IsNullOrEmpty(request.sortBy))
            //{
            //    switch (request.sortBy)
            //    {
            //        case "masv_desc": query = query.OrderByDescending(x => x.sv.MaSv); break;
            //        case "tensv_asc": query = query.OrderBy(x => x.sv.TenSv); break;
            //        case "tensv_desc": query = query.OrderByDescending(x => x.sv.TenSv); break;
            //    }
            //}
            #endregion

            #region paging

            //C1: Truy vấn Sql trong EF
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SinhVienDTO()
                {
                    MaSv = x.MaSv,
                    TenSv = x.TenSv,
                    DiaChi = x.DiaChi,
                    NgaySinh = x.NgaySinh,
                    GioiTinh = x.GioiTinh
                }).AsNoTracking().ToListAsync();


            //C2: Linq to Entities
            //var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            //   .Take(request.PageSize)
            //   .Select(x => new SinhVienDTO()
            //   {
            //       MaSv = x.sv.MaSv,
            //       TenSv = x.sv.TenSv,
            //       DiaChi = x.sv.DiaChi,
            //       NgaySinh = x.sv.NgaySinh,
            //       GioiTinh = x.sv.GioiTinh
            //   }).AsNoTracking().ToListAsync();

            var pagedResult = new PagedResult<SinhVienDTO>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
            #endregion
        }
    }
}
