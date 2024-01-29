using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.SinhVienDTOs
{
    /// <summary>
    /// Sinh viên DTO
    /// </summary>
    public class SinhVienDTO
    {
        /// <summary>
        /// mã sinh viên
        /// </summary>
        public string MaSv { get; set; }

        /// <summary>
        /// tên sinh viên
        /// </summary>
        public string TenSv { get; set; }

        /// <summary>
        /// giới tính
        /// </summary>
        public string GioiTinh { get; set; }

        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime NgaySinh { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        public string DiaChi { get; set; }

        /// <summary>
        /// mã lớp
        /// </summary>
        public Guid MaLop { get; set; }
    }
}
