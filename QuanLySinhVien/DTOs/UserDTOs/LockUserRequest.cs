using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.UserDTOs
{
    public class LockUserRequest
    {
        public string UserName { get; set; }
        public bool isLocked { get; set; }

    }
}
