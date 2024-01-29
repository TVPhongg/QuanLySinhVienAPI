using AutoMapper;
using AutoMapper.QueryableExtensions;
using QuanLySinhVien.Data.Context;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.BaseServices
{
    public abstract class BaseService<T, TDto> : IBaseService<T, TDto>
        where T: class
        where TDto : class
    {
        private readonly IMapper _mapper;
        private readonly QLSVContext _qLSVContext;
        public BaseService(IMapper mapper,
            QLSVContext qLSVContext)
        {
            _mapper = mapper;
            _qLSVContext = qLSVContext;
        }

        public async Task<T> Create(TDto model)
        {
            var modelToCreate = _mapper.Map<TDto, T>(model);
            await _qLSVContext.AddAsync(modelToCreate);
            await _qLSVContext.SaveChangesAsync();
            return modelToCreate;
        }

        public async Task<int> Delete(Guid Id)
        {
            var objId = await _qLSVContext.Set<T>().FindAsync(Id);
            if (objId == null)
            {
                throw new Exception($"Không tìm thấy đối tượng {Id}");
            }
            _qLSVContext.Set<T>().Remove(objId);
            return await _qLSVContext.SaveChangesAsync();
        }
     
        public async Task<TDto> GetById(Guid Id)
        {
            var objId = await _qLSVContext.Set<T>().FindAsync(Id);
            if (objId == null)
            {
                throw new Exception($"Không tìm thấy đối tượng {Id}");
            }
            var modelToGetById = _mapper.Map<TDto>(objId);
            return modelToGetById;

        }
     
        public async Task<T> Update(Guid Id, TDto model)
        {
            var objId = await _qLSVContext.Set<T>().FindAsync(Id);
            if (objId == null)            
                throw new Exception($"Không tìm thấy đối tượng {Id}");           
            var modelToUpdate = _mapper.Map<TDto, T>(model, objId);
             _qLSVContext.Update(modelToUpdate);
            await _qLSVContext.SaveChangesAsync();
            return modelToUpdate;
        }
    }
}
