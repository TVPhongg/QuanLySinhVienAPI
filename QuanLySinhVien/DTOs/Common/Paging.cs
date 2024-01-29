using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.SinhVienDTOs
{
    /// <summary>
    /// đối tượng phân trang
    /// </summary>
    public class Paging : PagingBase
    {
        /// <summary>
        /// từ khóa tìm kiếm
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// sắp xếp
        /// </summary>
        public string sortBy { get; set; }

    }
}
