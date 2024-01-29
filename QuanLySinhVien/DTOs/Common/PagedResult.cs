using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        /// <summary>
        /// danh sách các items
        /// </summary>
        public List<T> Items { set; get; }
    }
}
