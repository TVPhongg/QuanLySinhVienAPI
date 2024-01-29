using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Configuration;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Data.Context
{
    public class QLSVContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public QLSVContext(DbContextOptions<QLSVContext> options)
           : base(options)
        {
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiemThiConfig());
            modelBuilder.ApplyConfiguration(new GiangVienConfig());
            modelBuilder.ApplyConfiguration(new KhoaConfig());
            modelBuilder.ApplyConfiguration(new LopConfig());
            modelBuilder.ApplyConfiguration(new MonHocConfig());
            modelBuilder.ApplyConfiguration(new SinhVienConfig());
            modelBuilder.ApplyConfiguration(new AppUserConfig());
            modelBuilder.ApplyConfiguration(new AppRoleConfig());


            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }

        public DbSet<DiemThi> DiemThis { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
