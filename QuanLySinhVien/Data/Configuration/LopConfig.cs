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
    public class LopConfig : IEntityTypeConfiguration<Lop>
    {
        /// <summary>
        /// Cấu hình bảng Lớp
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Lop> builder)
        {
            builder.ToTable("Lop");
            builder.HasKey(l => l.IdLop);
            builder.Property(l => l.MaLop).HasMaxLength(250).IsRequired();
            builder.Property(l => l.TenLop).HasMaxLength(250).IsRequired();
            builder.HasOne<Khoa>(x => x.Khoa).WithMany(x => x.Lops).HasForeignKey(x => x.MaKhoa)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

        }    
    }
}
