using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.UserDTOs
{
    public class UpdateRequest
    {
        public Guid Id { get; set; }
        [Display(Name = "Tên họ")]
        public string FirstName { get; set; }
        [Display(Name = "Tên đệm")]
        public string LastName { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Adress { get; set; }
        [Display(Name = "Hòm thư")]
        public string Email { get; set; }
    }
}
