using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.NguoiDungServices
{
    public interface IUserService
    {
        Task<UserResult<string>> Login(LoginRequest request);
        Task<UserResult<bool>> Register(RegisterRequest request);
        Task<UserResult<bool>> Update(Guid id, UpdateRequest request);
        Task<UserResult<UserDTO>> GetById(Guid id);
        Task<UserResult<bool>> Delete(Guid id);
        Task<UserResult<bool>> RegisterAdmin(RegisterRequest request);
        Task<UserResult<bool>> ChangePassword(ChangePasswordRequest request);
        Task<UserResult<bool>> LockUser(LockUserRequest request);
        Task<UserResult<bool>> UnlockUser(LockUserRequest request);
        Task<AppUser> FindIdByUsername(string userName);

    }
}
