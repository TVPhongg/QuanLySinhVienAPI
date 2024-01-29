using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Entities
{
    /// <summary>
    /// Thông tin cơ bản của người dùng
    /// </summary>
    public class AppRole : IdentityRole<Guid>
    {
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Descrip { get; set; }
    }
}
