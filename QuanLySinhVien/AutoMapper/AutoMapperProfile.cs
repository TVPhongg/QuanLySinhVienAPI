using AutoMapper;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.DiemThiDTOs;
using QuanLySinhVien.DTOs.GiangVienDTOs;
using QuanLySinhVien.DTOs.KhoaDTOs;
using QuanLySinhVien.DTOs.LopDTOs;
using QuanLySinhVien.DTOs.MonHocDTO;
using QuanLySinhVien.DTOs.MonHocDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //mapper sinh viên
            CreateMap<SinhVienDTO, SinhVien>();
            CreateMap<SinhVien, SinhVienDTO>();
            CreateMap<ThemMoiSinhVienDTO, SinhVien>();
            CreateMap<CapNhatSinhVienDTO, SinhVien>();

            //mapper môn học
            CreateMap<MonHocDTO, MonHoc>();
            CreateMap<MonHoc, MonHocDTO>();
            CreateMap<ThemMoiMonHocDTO, MonHoc>();
            CreateMap<CapNhatMonHocDTO, MonHoc>();

            //mapper lớp
            CreateMap<LopDTO, Lop>();
            CreateMap<Lop, LopDTO>();
            CreateMap<ThemMoiLopDTO, Lop>();
            CreateMap<CapNhatLopDTO, Lop>();

            //mapper khoa
            CreateMap<KhoaDTO, Khoa>();
            CreateMap<Khoa, KhoaDTO>();
            CreateMap<ThemMoiKhoaDTO, Khoa>();
            CreateMap<CapNhatKhoaDTO, Khoa>();

            //mapper giảng viên
            CreateMap<GiangVienDTO, GiangVien>();
            CreateMap<GiangVien, GiangVienDTO>();
            CreateMap<ThemMoiGiangVienDTO, GiangVien>();
            CreateMap<CapNhatGiangVienDTO, GiangVien>();

            //mapper điểm thi
            CreateMap<DiemThiDTO, DiemThi>();
            CreateMap<DiemThi, DiemThiDTO>();
            CreateMap<ThemMoiDiemThiDTO, DiemThi>();
            CreateMap<CapNhatDiemThiDTO, DiemThi>();

        }
    }
}
