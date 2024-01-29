using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.Common
{
    /// <summary>
    /// đối tượng trả về kết quả cơ sở
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// true nếu thành công
        /// </summary>
        public bool IsSuccessed { get; set; }

        /// <summary>
        /// dòng thông báo trả về
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// đối tượng trả về
        /// </summary>
        public T ResultObj { get; set; }
    }
}
