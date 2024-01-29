using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.LopDTOs
{
    /// <summary>
    /// Lớp DTO
    /// </summary>
    public class LopDTO
    {

        /// <summary>
        /// Id lớp
        /// </summary>
        public Guid IdLop { get; set; }

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
