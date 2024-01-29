using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.DiemThiDTOs
{
    /// <summary>
    /// thêm mới điểm thi
    /// </summary>
    public class ThemMoiDiemThiDTO
    {
        /// <summary>
        /// mã sinh viên
        /// </summary>
        public Guid MaSv { get; set; }

        /// <summary>
        /// mã môn học
        /// </summary>
        public Guid MaMh { get; set; }

        /// <summary>
        /// lần thi
        /// </summary>
        public int LanThi { get; set; }

        /// <summary>
        /// điểm
        /// </summary>
        public double Diem { get; set; }
    }
}
