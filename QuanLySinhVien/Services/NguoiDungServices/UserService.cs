using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuanLySinhVien.Data.Context;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.UserDTOs;
using QuanLySinhVien.Services.QuyenNguoiDungServices;
using QuanLySinhVien.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Services.NguoiDungServices
{
    /// <summary>
    /// crud người dùng
    /// </summary>
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IRoleService _roleService;
        private readonly QLSVContext _qLSVContext;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config,
            QLSVContext qLSVContext,
            IRoleService roleService
            )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _qLSVContext = qLSVContext;
            _roleService = roleService;
        }
        /// <summary>
        /// thay doi mat khau cho nguoi dung
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserResult<bool>> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return new UserErrorResult<bool>("Tài khoản không tồn tại");
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
                return new UserErrorResult<bool>("Thay đổi mật khẩu thất bại");
            return new UserSuccessResult<bool>();
        }

        public async Task<UserResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return new UserErrorResult<bool>("User không tồn tại");
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new UserSuccessResult<bool>();
            return new UserErrorResult<bool>("Xóa thất bại");

        }
        /// <summary>
        /// tìm kiem Id theo ten nguoi dung
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public async Task<AppUser> FindIdByUsername(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }
        /// <summary>
        /// tim kiem theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResult<UserDTO>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new UserErrorResult<UserDTO>("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userDTO = new UserDTO()
            {

                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                //Roles = roles
            };
            return new UserSuccessResult<UserDTO>(userDTO);
        }

        /// <summary>
        /// khoa tai khoan
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<UserResult<bool>> LockUser(LockUserRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {

                var endDate = DateTime.Now;
                var lockUser = await _userManager.SetLockoutEnabledAsync(user, true);
                var lockDate = await _userManager.SetLockoutEndDateAsync(user, endDate);



                if (lockUser.Succeeded && lockDate.Succeeded)
                    return new UserSuccessResult<bool>();
                else return new UserErrorResult<bool>();


            }
            return new UserErrorResult<bool>("Không tồn tại người dùng!");

        }
        /// <summary>
        /// dang nhap
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserResult<string>> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>
                {
                new Claim("username", request.UserName),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };

                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                //    var token = CreateToken(claims);
                //    var refreshToken = GenerateRefreshToken();

                //    _ = int.TryParse(_config["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);
                //    user.RefreshToken = refreshToken;
                //    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                //    await _userManager.UpdateAsync(user);

                //    return new UserSuccessResult<string>(
                //        new
                //        {
                //            Token = new JwtSecurityTokenHandler().WriteToken(token),
                //            RefreshToken = refreshToken,
                //            Expiration = token.ValidTo
                //        });
                //}
                //return new UserErrorResult<string>("Đăng nhập thất bại");

                //claims: thông tin về người dùng(Key: loại Type và Value: giá trị của Type đó)(claims có thể là name, email, phone,..)

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"])); // key mã hóa
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature); // chữ ký, và kiểu mã hóa

                var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                   _config["Tokens:Issuer"], // nơi phát hành token 
                   claims, // claims
                   expires: DateTime.Now.AddHours(2), // time hết hạn của token
                   signingCredentials: creds); // chữ ký

                UserLogged userLogged = new UserLogged();
                userLogged.LogId = Guid.NewGuid();
                userLogged.MessageUser = "Success";
                userLogged.LoggedBy = user.UserName;
                userLogged.LoginTime = DateTime.Now;
                userLogged.UserId = user.Id;

                return new UserSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
            }

            else
                {
                    UserLogged userLogged = new UserLogged();
                    userLogged.LogId = Guid.NewGuid();
                    userLogged.MessageUser = "Fail";
                    userLogged.LoggedBy = user.UserName;
                    userLogged.LoginTime = DateTime.Now;
                    userLogged.UserId = user.Id;
                    return new UserErrorResult<string>("Đăng nhập thất bại");

                }

            }
        /// <summary>
        /// dang ky
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null)
                return new UserErrorResult<bool>("Tài khoản đã tồn tại!");

            user = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Adress = request.Adress,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new UserErrorResult<bool>("Đăng ký thất bại");
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new AppRole { Name = UserRoles.Admin, Descrip = "This is admin-role" });

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new AppRole { Name = UserRoles.User, Descrip = "This is user-role" });

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {

                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            return new UserSuccessResult<bool>();
        }
        /// <summary>
        /// đăng ký tài khoản admin
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<UserResult<bool>> RegisterAdmin(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null)
                return new UserErrorResult<bool>("Tài khoản đã tồn tại!");

            user = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Adress = request.Adress,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new UserErrorResult<bool>("Đăng ký thất bại");

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new AppRole { Name = UserRoles.Admin, Descrip = "Đây là admin-role" });

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new AppRole { Name = UserRoles.User, Descrip = "Đây là user-role" });

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return new UserSuccessResult<bool>();
        }
        /// <summary>
        /// mo khoa nguoi dung
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<UserResult<bool>> UnlockUser(LockUserRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {


                var lockUser = await _userManager.SetLockoutEnabledAsync(user, false);




                if (lockUser.Succeeded)
                    return new UserSuccessResult<bool>();
                else return new UserErrorResult<bool>();


            }
            return new UserErrorResult<bool>("Không tồn tại người dùng!");
        }
        /// <summary>
        /// cap nhat nguoi dung
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<UserResult<bool>> Update(Guid id, UpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return new UserErrorResult<bool>("Không tìm thấy tài khoản");
            }

            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Adress = request.Adress;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new UserSuccessResult<bool>();
            }
            return new UserErrorResult<bool>("Cập nhật thất bại");
        }
    
    }
}
