using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Entities
{
    /// <summary>
    /// bảng điểm thi
    /// </summary>
    public class DiemThi 
    {
        /// <summary>
        /// Id điểm thi
        /// </summary>
        public Guid IdDiemThi { get; set; }

        /// <summary>
        /// Mã sinh viên
        /// </summary>
        public Guid MaSv { get; set; } 

        /// <summary>
        /// Mã môn học
        /// </summary>
        public Guid MaMh { get; set; }

        /// <summary>
        /// Lần thi
        /// </summary>
        public int LanThi { get; set; }

        /// <summary>
        /// Điểm
        /// </summary>
        public double Diem { get; set; }

        /// <summary>
        /// Điều hướng tham chiếu tới bảng môn học
        /// </summary>
        public MonHoc MonHoc { get; set; }

        /// <summary>
        /// Điều hướng tham chiếu tới bảng sinh viên
        /// </summary>
        public SinhVien SinhVien { get; set; }
    }
}
