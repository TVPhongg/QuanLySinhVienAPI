using FluentValidation;
using Microsoft.EntityFrameworkCore;

using QuanLySinhVien.AutoMapper;
using QuanLySinhVien.Data.Context;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.DTOs.DiemThiDTOs;
using QuanLySinhVien.DTOs.GiangVienDTOs;
using QuanLySinhVien.DTOs.KhoaDTOs;
using QuanLySinhVien.DTOs.LopDTOs;
using QuanLySinhVien.DTOs.MonHocDTOs;
using QuanLySinhVien.DTOs.SinhVienDTOs;
using QuanLySinhVien.Validation.DiemThiValidation;
using QuanLySinhVien.Validation.GiangVienValidation;
using QuanLySinhVien.Validation.KhoaValidation;
using QuanLySinhVien.Validation.LopValidation;
using QuanLySinhVien.Validation.MonHocValidation;
using QuanLySinhVien.Validation.SinhVienValidation;
using QuanLySinhVien.Validation;
using FluentValidation.AspNetCore;
using QuanLySinhVien.Services.MonHocServices;
using QuanLySinhVien.Services.KhoaServices;
using QuanLySinhVien.Services.GiangVienServices;
using QuanLySinhVien.Services.LopServices;
using QuanLySinhVien.Services.DiemThiServices;
using QuanLySinhVien.Services.SinhVienServices;
using QuanLySinhVien.DTOs.MonHocDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using QuanLySinhVien.Services.NguoiDungServices;
using QuanLySinhVien.Services.QuyenNguoiDungServices;
using QuanLySinhVien.Services.TokenServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddDbContext<QLSVContext>(
       options => options.UseSqlServer("name=ConnectionStrings:QLSVDataBase"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper
(typeof(Program).Assembly);

builder.Services.AddTransient<QLSVContext>();
builder.Services.AddTransient<IMonHocService, MonHocService>();
builder.Services.AddTransient<IKhoaService, KhoaService>();
builder.Services.AddTransient<IGiangVienService, GiangVienService>();
builder.Services.AddTransient<ILopService, LopService>();
builder.Services.AddTransient<IDiemThiService, DiemThiService>();
builder.Services.AddTransient<ISinhVienService, SinhVienService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();



builder.Services.AddControllers()
    .AddFluentValidation(x =>
    {
        x.ImplicitlyValidateChildProperties = true;
    });

builder.Services.AddTransient<IValidator<SinhVienDTO>, SinhVienValidator>();
builder.Services.AddTransient<IValidator<MonHocDTO>, MonHocValidator>();
builder.Services.AddTransient<IValidator<LopDTO>, LopValidator>();
builder.Services.AddTransient<IValidator<KhoaDTO>, KhoaValidator>();
builder.Services.AddTransient<IValidator<GiangVienDTO>, GiangVienValidator>();
builder.Services.AddTransient<IValidator<DiemThiDTO>, DiemThiValidator>();
builder.Services.AddTransient<ITokenService, TokenService>();

//đăng ký dịch vụ Identity
builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<QLSVContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // setup password
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;


    // Setup lockout
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Set up User.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

});



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger For App Solution", Version = "v1" }); 
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header, 
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer"); // issuer : nơi phát hành token
string signingKey = builder.Configuration.GetValue<string>("Tokens:Key"); // key: dùng để mã hóa
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey); // chuyến sang kiểu byte

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, //Kiểm tra xem server render của Access Token
        ValidIssuer = issuer, // thông tin của render access token.
        ValidateAudience = true,
        ValidAudience = issuer, // thông tin đk đảm bảo, đk đặt ở server
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.FromMinutes(5),
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
});



builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("AuthUsers", policy => policy.RequireAuthenticatedUser());
    opt.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.Enrich.FromLogContext()
.CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
