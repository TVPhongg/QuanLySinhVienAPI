using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.DiemThiDTOs
{
    /// <summary>
    /// đối tượng DTO điểm thi 
    /// </summary>
    public class DiemThiDTO
    {
        /// <summary>
        /// Id điểm thi
        /// </summary>
        public Guid IdDiemThi { get; set; }

        /// <summary>
        /// mã sinh viên
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
        /// điểm
        /// </summary>
        public double Diem { get; set; }
    }
}
