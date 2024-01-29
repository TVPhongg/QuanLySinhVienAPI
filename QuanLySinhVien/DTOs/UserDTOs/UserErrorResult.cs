using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.UserDTOs
{
    public class UserErrorResult<T> : UserResult<T>
    {
        public UserErrorResult()
        {
            IsSuccessed = false;
        }
        public UserErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }
    }
}
