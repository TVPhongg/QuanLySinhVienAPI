using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Entities
{
    /// <summary>
    /// bảng sinh viên
    /// </summary>
    public class SinhVien
    {
      /// <summary>
      /// Id sinh viên
      /// </summary>
        public Guid IdSinhVien { get; set; }

        /// <summary>
        /// Mã sinh viên
        /// </summary>
        public string MaSv { get; set; }

        /// <summary>
        /// Tên sinh viên
        /// </summary>
        public string TenSv { get; set; }

        /// <summary>
        /// Giới tính
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
        /// Mã lớp
        /// </summary>
        public Guid MaLop { get; set; }

        /// <summary>
        /// điều hướng tập hợp đến bảng điểm thi
        /// </summary>
        public virtual ICollection<DiemThi> DiemThis { get; set; }

        /// <summary>
        /// điều hướng tham chiếu dến bảng lớp
        /// </summary>
        public virtual Lop Lop { get; set; }
    }
}
