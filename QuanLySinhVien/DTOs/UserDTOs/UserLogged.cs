using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.UserDTOs
{
    public class UserLogged
    {
        /// <summary>
        /// Id cua nguoi dung
        /// </summary>
        [Key]
        public Guid LogId { get; set; }
        /// <summary>
        /// thong bao
        /// </summary>
        [Required]
        public string MessageUser { get; set; }
        /// <summary>
        /// dang nhap boi ai
        /// </summary>
        [Required]

        public string LoggedBy { get; set; }
        /// <summary>
        /// thơi gian dang nhap
        /// </summary>
        [Required]
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// Id dang nhap
        /// </summary>
        [Required]

        public Guid UserId { get; set; }
    }
}
