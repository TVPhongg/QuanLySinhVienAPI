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

    public class GiangVienConfig : IEntityTypeConfiguration<GiangVien>
    {
        /// <summary>
        /// Cấu hình bảng Giảng Viên
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<GiangVien> builder)
        {
            builder.ToTable("GiangVien");
            builder.HasKey(gv => gv.IdGiangVien);
            builder.Property(gv => gv.MaGv).HasMaxLength(250).IsRequired();
            builder.Property(gv => gv.TenGv).HasMaxLength(250).IsRequired();
            builder.Property(gv => gv.ChuyenNganh).HasMaxLength(250);
            builder.HasOne<Khoa>(x => x.Khoa).WithMany(x => x.GiangViens).HasForeignKey(x => x.MaKhoa)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

        }    
    }

}
