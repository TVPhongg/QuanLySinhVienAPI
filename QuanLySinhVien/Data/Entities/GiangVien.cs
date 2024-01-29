using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Entities
{
    /// <summary>
    /// bảng giảng viên
    /// </summary>
    public class GiangVien 
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
        /// Tên giẩng viên
        /// </summary>
        public string TenGv { get; set; }

        /// <summary>
        /// Chuyên ngành 
        /// </summary>
        public string ChuyenNganh { get; set; }

        /// <summary>
        /// Mã khoa
        /// </summary>
        public Guid MaKhoa { get; set; }

        /// <summary>
        /// Điều hướng tham chiếu tới bảng khoa
        /// </summary>
        public Khoa Khoa { get; set; }
    }
}
