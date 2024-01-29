using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.LopDTOs
{
    /// <summary>
    /// cập nhật lớp DTO
    /// </summary>
    public class CapNhatLopDTO
    {
        /// <summary>
        /// mã lớp
        /// </summary>
        public string MaLop { get; set; }

        /// <summary>
        /// tên lớp
        /// </summary>
        public string TenLop { get; set; }

        /// <summary>
        /// mã khoa
        /// </summary>
        public Guid MaKhoa { get; set; }
    }
}
