using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.SinhVienDTOs
{
    /// <summary>
    /// bảng phân trang cơ sở
    /// </summary>
    public class PagingBase 
    {
        /// <summary>
        /// chỉ mục trang
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// kích thước trang
        /// </summary>
        public int PageSize { get; set; }
    }
}
