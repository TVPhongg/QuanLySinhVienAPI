using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.MonHocDTOs
{
    /// <summary>
    /// thêm mới môn học DTO
    /// </summary>
    public class ThemMoiMonHocDTO
    {
        /// <summary>
        /// mã môn học
        /// </summary>
        public string MaMh { get; set; }

        /// <summary>
        /// tên môn học
        /// </summary>
        public string TenMh { get; set; }

        /// <summary>
        /// số giờ
        /// </summary>
        public int SoGio { get; set; }
    }
}
