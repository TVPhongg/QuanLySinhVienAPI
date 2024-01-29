using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.UserDTOs
{
    public class UserSuccessResult<T> : UserResult<T>
    {
        public UserSuccessResult()
        {
            IsSuccessed = true;
        }
        public UserSuccessResult(T objectResult)
        {
            IsSuccessed = true;
            ObjectResult = objectResult;

        }
    }
}
