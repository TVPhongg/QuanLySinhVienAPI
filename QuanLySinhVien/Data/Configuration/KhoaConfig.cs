using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Configuration
{

    public class KhoaConfig : IEntityTypeConfiguration<Khoa>
    {
        /// <summary>
        /// Cấu hình bảng Khoa
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Khoa> builder)
        {
            builder.ToTable("Khoa");
            builder.HasKey(kh => kh.IdKhoa);
            builder.Property(kh => kh.MaKhoa).HasMaxLength(250).IsRequired();
            builder.Property(kh => kh.TenKhoa).HasMaxLength(250).IsRequired();
        }


    }

}
