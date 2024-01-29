using FluentValidation;
using QuanLySinhVien.DTOs.KhoaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Validation.KhoaValidation
{
    public class KhoaValidator : AbstractValidator<KhoaDTO>
    {
        public KhoaValidator()
        {
            RuleFor(x => x.MaKhoa).NotNull().NotEmpty().WithMessage("Mã khoa không được để trống").DependentRules(() =>
            {
                RuleFor(x => x.MaKhoa).Matches(@"^[a-zA-Z0-9]\S+$").WithMessage("Mã khoa không có dấu cách").DependentRules(() =>
                {
                    RuleFor(x => x.MaKhoa).Matches(@"^[A-Za-z][A-Za-z0-9_]{5,29}$").WithMessage("Mã khoa không có ký tự tiếng việt");
                });
            });

            RuleFor(x => x.TenKhoa).NotEmpty().WithMessage("Tên khoa không được để trống");
        }
    }
}
