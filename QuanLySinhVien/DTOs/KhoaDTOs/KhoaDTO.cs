using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.KhoaDTOs
{
    /// <summary>
    /// Khoa
    /// </summary>
    public class KhoaDTO
    {
        /// <summary>
        /// Id khoa
        /// </summary>
        public Guid IdKhoa { get; set; }

        /// <summary>
        /// Mã khoa
        /// </summary>
        public string MaKhoa { get; set; }

        /// <summary>
        /// Tên khoa
        /// </summary>
        public string TenKhoa { get; set; }
    }
}
