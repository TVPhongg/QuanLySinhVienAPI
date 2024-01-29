using FluentValidation;
using QuanLySinhVien.DTOs.LopDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Validation.LopValidation
{
    public class LopValidator : AbstractValidator<LopDTO>
    {
        public LopValidator()
        {
            RuleFor(x => x.MaLop).NotNull().NotEmpty().WithMessage("Mã lớp không được để trống").DependentRules(() =>
            {
                RuleFor(x => x.MaLop).Matches(@"^[a-zA-Z0-9]\S+$").WithMessage("Mã lớp không có dấu cách").DependentRules(() =>
                {
                    RuleFor(x => x.MaLop).Matches(@"^[A-Za-z][A-Za-z0-9_]{5,29}$").WithMessage("Mã lớp không có ký tự tiếng việt");
                });
            });

            RuleFor(x => x.TenLop).NotEmpty().WithMessage("Tên môn học không được để trống");
        }
    }
}
