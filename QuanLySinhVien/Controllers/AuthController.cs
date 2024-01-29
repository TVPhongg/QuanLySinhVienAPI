using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Data.Context;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Services.TokenServices;
using System.Security.Claims;

namespace QuanLySinhVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly QLSVContext _qLSVContext;
        //private readonly ITokenService _tokenService;
        //public AuthController(QLSVContext qLSVContext, ITokenService tokenService)
        //{
        //    _qLSVContext = qLSVContext ?? throw new ArgumentNullException(nameof(qLSVContext));
        //    _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        //}
        //[HttpPost, Route("login")]
        ////public IActionResult Login([FromBody] AppUser loginModel)
        //{
        //    if (loginModel is null)
        //    {
        //        return BadRequest("Invalid client request");
        //    };
        //     var user = await _userManager.FindByNameAsync(request.UserName);
        //    if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
        //    //var user = _qLSVContext.AppUsers.FirstOrDefault(u =>
        //    //    (u.UserName == loginModel.UserName) && ());
        //    if (user is null)
        //        return Unauthorized();
        //    var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, loginModel.UserName),
        //    new Claim(ClaimTypes.Role, "Manager")
        //};
        //    var accessToken = _tokenService.GenerateAccessToken(claims);
        //    var refreshToken = _tokenService.GenerateRefreshToken();
        //    user.RefreshToken = refreshToken;
        //    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        //    _userContext.SaveChanges();
        //    return Ok(new AuthenticatedResponse
        //    {
        //        Token = accessToken,
        //        RefreshToken = refreshToken
        //    });
        //}
    }
}
