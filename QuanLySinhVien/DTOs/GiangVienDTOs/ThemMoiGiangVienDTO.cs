using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.GiangVienDTOs
{
    /// <summary>
    /// thêm mới giảng viên DTO
    /// </summary>
    public class ThemMoiGiangVienDTO
    {
        /// <summary>
        /// mã giảng viên
        /// </summary>
        public string MaGv { get; set; }

        /// <summary>
        /// tên giảng viên
        /// </summary>
        public string TenGv { get; set; }

        /// <summary>
        /// chuyên ngành
        /// </summary>
        public string ChuyenNganh { get; set; }

        /// <summary>
        /// mã khoa
        /// </summary>
        public Guid MaKhoa { get; set; }
    }
}
