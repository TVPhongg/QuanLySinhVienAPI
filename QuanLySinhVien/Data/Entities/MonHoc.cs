using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Entities
{
    /// <summary>
    /// bảng môn học
    /// </summary>
    public class MonHoc 
    {
        /// <summary>
        /// Id môn học
        /// </summary>
        public Guid IdMonHoc { get; set; }

        /// <summary>
        /// Mã môn học
        /// </summary>
        public string MaMh { get; set; }

        /// <summary>
        /// Tên môn học
        /// </summary>
        public string TenMh { get; set; }

        /// <summary>
        /// Số giờ
        /// </summary>
        public int SoGio { get; set; }


        /// <summary>
        /// Điều hướng tập hợp tới bảng điểm thi
        /// </summary>
        public virtual ICollection<DiemThi> DiemThis { get; set; }
    }
}
