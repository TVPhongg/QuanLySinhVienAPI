using FluentValidation;
using QuanLySinhVien.DTOs.GiangVienDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Validation.GiangVienValidation
{
    public class GiangVienValidator : AbstractValidator<GiangVienDTO>
    {
        public GiangVienValidator()
        {
            RuleFor(x => x.MaGv).NotNull().NotEmpty().WithMessage("Mã giảng viên không được để trống").DependentRules(() =>
            {
                RuleFor(x => x.MaGv).Matches(@"^[a-zA-Z0-9]\S+$").WithMessage("Mã giảng viên không có dấu cách").DependentRules(() =>
                {
                    RuleFor(x => x.MaGv).Matches(@"^[A-Za-z][A-Za-z0-9_]{5,29}$").WithMessage("Mã giảng viên không có ký tự tiếng việt");
                });
            });

            RuleFor(x => x.TenGv).NotEmpty().WithMessage("Tên giảng viên không được để trống");
        }
    }
}
