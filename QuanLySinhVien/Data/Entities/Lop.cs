using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Entities
{
    /// <summary>
    /// Bảng lớp
    /// </summary>
    public class Lop 
    {
        /// <summary>
        /// Id lớp
        /// </summary>
        public Guid IdLop { get; set; }

        /// <summary>
        /// Mã lớp
        /// </summary>
        public string MaLop { get; set; }

        /// <summary>
        /// Tên lớp
        /// </summary>
        public string TenLop { get; set; }

        /// <summary>
        /// Mã Khoa
        /// </summary>
        public Guid MaKhoa { get; set; }

        /// <summary>
        /// điều hướng tập hợp tới bảng sinh viên
        /// </summary>
        public virtual ICollection<SinhVien> SinhViens { get; set; }

        /// <summary>
        /// điều hướng tham chiếu tới bảng khoa
        /// </summary>
        public Khoa Khoa { get; set; }
    }
}
