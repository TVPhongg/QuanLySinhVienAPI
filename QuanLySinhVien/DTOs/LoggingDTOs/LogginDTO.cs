using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DTOs.LoggingDTOs
{
    public class LogginDTO
    {
        [Key]
        public Guid LogId { get; set; }
        public string MessageUser { get; set; }
        public string LoggedBy { get; set; }
        public DateTime loginTime { get; set; }
    }
}
