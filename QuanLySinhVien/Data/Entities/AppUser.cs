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
    public class AppUser : IdentityUser<Guid>
    {
        /// <summary>
        /// Tên đệm
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Tên họ
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// mã dùng để tạo new access token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// thời gian hết hạn của refresh token
        /// </summary>
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
