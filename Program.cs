using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApi.Common;
using WebApi.Data.EF;
using WebApi.Data.Entites;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
var JwtSetting = builder.Configuration.GetSection("JWTSetting");

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // ✅ Cho phép deserialize camelCase;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddDbContext<ThietbiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ThietbiDb"), sqlServerOptionsAction =>
{
    sqlServerOptionsAction.EnableRetryOnFailure();
}));
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ThietbiDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = JwtSetting["ValiAudience"],
            ValidIssuer = JwtSetting["ValiIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting.GetSection("SecurityKey").Value!))
        };
    });

builder.Services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"C:\keys\"));

builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IPhongbanService, PhongbanService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChucvuService, ChucvuService>();
builder.Services.AddTransient<IDonvitinhService, DonvitinhService>();
builder.Services.AddTransient<ILoaithietbiService, LoaithietbiService>();
builder.Services.AddTransient<ITonghopthietbiService, TonghopthietbiService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<INhanvienService, NhanvienService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IUserRoleService, UserRoleService>();
builder.Services.AddTransient<IMayXucService, MayXucService>();
builder.Services.AddTransient<ITonghopmayxucService, TonghopmayxucService>();
builder.Services.AddTransient<ICameraService, CameraService>();
builder.Services.AddTransient<ITonghopcameraService, TonghopcameraService>();
builder.Services.AddTransient<IThongsokythuatmayxucService, ThongsokythuatmayxucService>();
builder.Services.AddTransient<INhatkymayxucService, NhatkymayxucService>();
builder.Services.AddTransient<IToitrucService, ToitrucService>();
builder.Services.AddTransient<ITonghoptoitrucService, TonghoptoitrucService>();
builder.Services.AddTransient<INhatkyTonghoptoitrucService, NhatkyTonghoptoitrucService>();
builder.Services.AddTransient<IDanhmuctoitrucService, DanhmuctoitrucService>();
builder.Services.AddTransient<IThongsokythuattoitrucService, ThongsokythuattoitrucService>();
builder.Services.AddTransient<ICapdienService, CapdienService>();
builder.Services.AddTransient<IDanhmucquatgioService, DanhmucquatgioService>();
builder.Services.AddTransient<IThongsoquatgioService, ThongsoquatgioService>();
builder.Services.AddTransient<ITonghopquatgioService, TonghopquatgioService>();
builder.Services.AddTransient<INhatkyquatgioService, NhatkyquatgioService>();
builder.Services.AddTransient<IDanhmucbomnuocService, DanhmucbomnuocService>();
builder.Services.AddTransient<INhatkybomnuocService, NhatkybomnuocService>();
builder.Services.AddTransient<IThongsobomnuocService, ThongsobomnuocService>();
builder.Services.AddTransient<ITonghopbomnuocService, TonghopbomnuocService>();
builder.Services.AddTransient<ICapdienService, CapdienService>();
builder.Services.AddTransient<ITonghopcapdienService, TonghopcapdienService>();
builder.Services.AddTransient<IDanhmucBalangService, DanhmucBalangService>();
builder.Services.AddTransient<ITonghopbalangService, TonghopbalangService>();
builder.Services.AddTransient<IDanhmucKhoanService, DanhmucKhoanService>();
builder.Services.AddTransient<ITonghopKhoanService, TonghopKhoanService>();
builder.Services.AddTransient<IDanhmucKhoanBalangService, DanhmucKhoanBalangService>();
builder.Services.AddTransient<IDanhmucMayCaoService, DanhmucMayCaoService>();
builder.Services.AddTransient<INhatkyMayCaoService, NhatkyMayCaoService>();
builder.Services.AddTransient<IThongsokythuatmaycaoService, ThongsokythuatmaycaoService>();
builder.Services.AddTransient<ITonghopmaycaoService, TonghopmaycaoService>();
builder.Services.AddTransient<IDanhmucNeoService, DanhmucNeoService>();
builder.Services.AddTransient<IThongsoNeoService, ThongsoNeoService>();
builder.Services.AddTransient<ITonghopneoService, TonghopneoService>();
builder.Services.AddTransient<IDanhmucbangtaiService, DanhmucbangtaiService>();
builder.Services.AddTransient<INhatkybangtaiService, NhatkybangtaiService>();
builder.Services.AddTransient<IThongsokythuatbangtaiService, ThongsokythuatbangtaiService>();
builder.Services.AddTransient<ITonghopbangtaiService, TonghopbangtaiService>();
builder.Services.AddTransient<IDanhmucRoleService, DanhmucRoleService>();
builder.Services.AddTransient<ITonghopRoleService, TonghopRoleService>();
builder.Services.AddTransient<IDanhmucBienApService, DanhmucBienApService>();
builder.Services.AddTransient<IThongsobienapService, ThongsobienapService>();
builder.Services.AddTransient<IDanhmucAptomatKhoidongtuService, DanhmucAptomatKhoidongtuService>();
builder.Services.AddTransient<IDanhmucgiacotthuylucService, DanhmucgiacotthuylucService>();
builder.Services.AddTransient<ITonghopgiacotthuylucService, TonghopgiacotthuylucService>();
builder.Services.AddTransient<IThongsoAptomatKhoidongtuService, ThongsoAptomatKhoidongtuService>();
builder.Services.AddTransient<INhatkyaptomatkhoidongtuService, NhatkyaptomatkhoidongtuService>();
builder.Services.AddTransient<IDanhmucgiacotService, DanhmucgiacotService>();
builder.Services.AddTransient<ICapnhatgiacotService, CapnhatgiacotService>();
builder.Services.AddTransient<ITonghopbienapService, TonghopbienapService>();
builder.Services.AddTransient<ITonghopKhoanBalangService, TonghopKhoanBalangService>();
builder.Services.AddTransient<ITonghopaptomatkhoidongtuService, TonghopaptomatkhoidongtuService>();
builder.Services.AddTransient<IThietBiService, ThietBiService>();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddHttpsRedirection(option => option.HttpsPort = 5001);
builder.Services.AddSwaggerGen(c =>
{
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

var app = builder.Build();
//var myOrigins = "_myOrigins";
//builder.Services.AddCors(options => options.AddPolicy(name: myOrigins,
//    policy =>
//    {
//        policy.WithOrigins("http://localhost:5252").AllowAnyMethod().AllowAnyHeader();
//    }
//    ));
// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images")),
    RequestPath = new PathString("/wwwroot/Images")
});
app.UseDirectoryBrowser(new DirectoryBrowserOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images")),
    RequestPath = new PathString("/wwwroot/Images")
});

app.UseRouting();
app.UseCors(options => options.WithOrigins("http://localhost:5005", "http://localhost:3333", "http://localhost:3334", "http://192.168.10.8:5005", "http://172.16.18.37:3333").AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
