using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.UserDTOs
{
    public class UserDTO
    {
        [Display(Name = "Tên họ")]
        public string FirstName { get; set; }
        [Display(Name = "Tên đệm")]
        public string LastName { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Adress { get; set; }
        [Display(Name = "Hòm thư")]
        public string Email { get; set; }
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }
    }
}
