using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.GiangVienDTOs
{
    /// <summary>
    /// Giảng viên
    /// </summary>
    public class GiangVienDTO
    {

        /// <summary>
        /// Id giảng viên
        /// </summary>
        public Guid IdGiangVien { get; set; }

        /// <summary>
        /// Mã giảng viên
        /// </summary>
        public string MaGv { get; set; }

        /// <summary>
        /// Tên giảng viên
        /// </summary>
        public string TenGv { get; set; }

        /// <summary>
        /// chuyên ngành
        /// </summary>
        public string ChuyenNganh { get; set; }

        /// <summary>
        /// Mã khoa
        /// </summary>
        public Guid MaKhoa { get; set; }
    }
}
