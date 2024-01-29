using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.UserDTOs
{
    public class UserResult<T>
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T ObjectResult { get; set; }
    }
}
