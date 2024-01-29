using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Entities
{
    /// <summary>
    /// bảng khoa
    /// </summary>
    public class Khoa 
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

        /// <summary>
        /// Điều hướng tập hợp tới bảng lớp
        /// </summary>
        public virtual ICollection<Lop> Lops { get; set; }

        /// <summary>
        /// Điều hướng tập hợp tới bảng giảng viên
        /// </summary>
        public virtual ICollection<GiangVien> GiangViens { get; set; }
    }
}
