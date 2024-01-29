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
    public class MonHocConfig : IEntityTypeConfiguration<MonHoc>
    {
        /// <summary>
        /// Cấu hình bảng Môn Học
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<MonHoc> builder)
        {
            builder.ToTable("MonHoc");
            builder.HasKey(mh => mh.IdMonHoc);
            builder.Property(mh => mh.TenMh).HasMaxLength(250).IsRequired();
            builder.Property(mh => mh.MaMh).HasMaxLength(250).IsRequired();
        }
    }
}
