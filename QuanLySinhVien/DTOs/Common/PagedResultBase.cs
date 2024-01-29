using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.Common
{
    /// <summary>
    /// bảng kết quả phân trang
    /// </summary>
    public class PagedResultBase
    {
        /// <summary>
        /// chỉ mục trang
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// kích thước trang
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// số lượng bản ghi
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// số lượng trang
        /// </summary>
        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecords / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
