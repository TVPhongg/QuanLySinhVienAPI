using FluentValidation;
using QuanLySinhVien.DTOs.DiemThiDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Validation.DiemThiValidation
{
    public class DiemThiValidator : AbstractValidator<DiemThiDTO>
    {
        public DiemThiValidator()
        {         
            RuleFor(x => x.MaSv).NotNull().NotEmpty().WithMessage("Mã sinh viên không được để trống");
            RuleFor(x => x.MaMh).NotNull().NotEmpty().WithMessage("Mã môn học không được để trống");
        }
    }
}
