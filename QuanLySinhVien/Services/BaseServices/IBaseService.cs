using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.BaseServices
{
    public interface IBaseService<T, TDto>
        where T : class
        where TDto : class
    {
        Task<T> Create(TDto model);
        Task<T> Update(Guid Id, TDto model);
        Task<int> Delete(Guid Id);
        Task<TDto> GetById(Guid Id);

    }
}
