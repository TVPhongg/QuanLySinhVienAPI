using FluentValidation;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Validation.SinhVienValidation
{
    public class SinhVienValidator : AbstractValidator<SinhVienDTO>
    {
        public SinhVienValidator()
        {

			RuleFor(x => x.MaSv).NotEmpty().WithMessage("Mã sinh viên không được để trống").DependentRules(() =>
			{
				RuleFor(x => x.MaSv).Matches(@"^[a-zA-Z0-9]\S+$").WithMessage("Mã sinh viên không có dấu cách").DependentRules(() =>
				{
					RuleFor(x => x.MaSv).Matches(@"^[A-Za-z0-9_]{5,29}$").WithMessage("Mã sinh viên không có ký tự tiếng việt");
				});
			});

			RuleFor(x => x.TenSv).NotEmpty().WithMessage("Tên sinh viên không được để trống");
		}
    }
}
