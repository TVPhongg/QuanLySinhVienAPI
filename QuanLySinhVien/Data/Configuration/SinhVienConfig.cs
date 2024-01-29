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
    public class SinhVienConfig : IEntityTypeConfiguration<SinhVien>
    {
        /// <summary>
        /// Cấu hình bảng Sinh Viên
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<SinhVien> builder)
        {
            builder.ToTable("SinhVien");
            builder.HasKey(sv => sv.IdSinhVien);
            builder.Property(sv => sv.MaSv).HasMaxLength(250).IsRequired();
            builder.Property(sv => sv.TenSv).HasMaxLength(250).IsRequired();
            builder.Property(sv => sv.GioiTinh).HasMaxLength(12);
            builder.Property(sv => sv.DiaChi).HasMaxLength(250);

            builder.HasOne<Lop>(x => x.Lop).WithMany(x => x.SinhViens).HasForeignKey(x => x.MaLop)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
       
    }
}
