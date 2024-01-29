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

    public class DiemThiConfig : IEntityTypeConfiguration<DiemThi>
    {
        /// <summary>
        /// Cấu hình bảng Điểm Thi
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<DiemThi> builder)
        {
            builder.ToTable("DiemThi");
            builder.HasKey(dt => dt.IdDiemThi);          
            builder.Property(dt => dt.Diem).IsRequired();
            builder.Property(dt => dt.LanThi).IsRequired();

            builder.HasOne<MonHoc>(x => x.MonHoc).WithMany(x => x.DiemThis).HasForeignKey(x => x.MaMh)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<SinhVien>(x => x.SinhVien).WithMany(x => x.DiemThis).HasForeignKey(x => x.MaSv)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
