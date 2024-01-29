using FluentValidation;
using QuanLySinhVien.DTOs.MonHocDTO;
using QuanLySinhVien.DTOs.MonHocDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Validation.MonHocValidation
{
    public class MonHocValidator : AbstractValidator<MonHocDTO>
    {
        public MonHocValidator()
        {
            RuleFor(x => x.MaMh).NotNull().NotEmpty().WithMessage("Mã môn học không được để trống").DependentRules(() =>
            {
                RuleFor(x => x.MaMh).Matches(@"^[a-zA-Z0-9]\S+$").WithMessage("Mã môn học không có dấu cách").DependentRules(() =>
                {
                    RuleFor(x => x.MaMh).Matches(@"^[A-Za-z][A-Za-z0-9_]{5,29}$").WithMessage("Mã môn học không có ký tự tiếng việt");
                });
            });

            RuleFor(x => x.TenMh).NotEmpty().WithMessage("Tên môn học không được để trống");
        }
    }
}
