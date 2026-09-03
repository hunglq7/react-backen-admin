using Api.Services;
using WebApi.Services;
using Microsoft.AspNetCore.Identity;
using WebApi.Data.Entites;
using WebApi.Common;
namespace WebApi.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Identity Services
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();

            // System & Infrastructure Services
            services.AddTransient<IPhongbanService, PhongbanService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IChucvuService, ChucvuService>();
            services.AddTransient<IDonvitinhService, DonvitinhService>();
            services.AddTransient<ILoaithietbiService, LoaithietbiService>();
            services.AddTransient<ITonghopthietbiService, TonghopthietbiService>();
            services.AddTransient<IStorageService, FileStorageService>();
            services.AddTransient<INhanvienService, NhanvienService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IThietBiService, ThietBiService>();

            // Domain Services - Máy Xúc & Camera
            services.AddTransient<IMayXucService, MayXucService>();
            services.AddTransient<ITonghopmayxucService, TonghopmayxucService>();
            services.AddTransient<IThongsokythuatmayxucService, ThongsokythuatmayxucService>();
            services.AddTransient<INhatkymayxucService, NhatkymayxucService>();
            services.AddTransient<ICameraService, CameraService>();
            services.AddTransient<ITonghopcameraService, TonghopcameraService>();

            // Domain Services - Tời Trục
            services.AddTransient<IToitrucService, ToitrucService>();
            services.AddTransient<ITonghoptoitrucService, TonghoptoitrucService>();
            services.AddTransient<INhatkyTonghoptoitrucService, NhatkyTonghoptoitrucService>();
            services.AddTransient<IDanhmuctoitrucService, DanhmuctoitrucService>();
            services.AddTransient<IThongsokythuattoitrucService, ThongsokythuattoitrucService>();

            // Domain Services - Quạt Gió & Bơm Nước
            services.AddTransient<IDanhmucquatgioService, DanhmucquatgioService>();
            services.AddTransient<IThongsoquatgioService, ThongsoquatgioService>();
            services.AddTransient<ITonghopquatgioService, TonghopquatgioService>();
            services.AddTransient<INhatkyquatgioService, NhatkyquatgioService>();
            services.AddTransient<IDanhmucbomnuocService, DanhmucbomnuocService>();
            services.AddTransient<INhatkybomnuocService, NhatkybomnuocService>();
            services.AddTransient<IThongsobomnuocService, ThongsobomnuocService>();
            services.AddTransient<ITonghopbomnuocService, TonghopbomnuocService>();

            // Domain Services - Cáp Điện & Ba Lăng & Khoan
            services.AddTransient<ICapdienService, CapdienService>();
            services.AddTransient<ITonghopcapdienService, TonghopcapdienService>();
            services.AddTransient<IDanhmucBalangService, DanhmucBalangService>();
            services.AddTransient<ITonghopbalangService, TonghopbalangService>();
            services.AddTransient<IDanhmucKhoanService, DanhmucKhoanService>();
            services.AddTransient<ITonghopKhoanService, TonghopKhoanService>();
            services.AddTransient<IDanhmucKhoanBalangService, DanhmucKhoanBalangService>();
            services.AddTransient<ITonghopKhoanBalangService, TonghopKhoanBalangService>();

            // Domain Services - Máy Cào & Neo & Băng Tải
            services.AddTransient<IDanhmucMayCaoService, DanhmucMayCaoService>();
            services.AddTransient<INhatkyMayCaoService, NhatkyMayCaoService>();
            services.AddTransient<IThongsokythuatmaycaoService, ThongsokythuatmaycaoService>();
            services.AddTransient<ITonghopmaycaoService, TonghopmaycaoService>();
            services.AddTransient<IDanhmucNeoService, DanhmucNeoService>();
            services.AddTransient<IThongsoNeoService, ThongsoNeoService>();
            services.AddTransient<ITonghopneoService, TonghopneoService>();
            services.AddTransient<IDanhmucbangtaiService, DanhmucbangtaiService>();
            services.AddTransient<INhatkybangtaiService, NhatkybangtaiService>();
            services.AddTransient<IThongsokythuatbangtaiService, ThongsokythuatbangtaiService>();
            services.AddTransient<ITonghopbangtaiService, TonghopbangtaiService>();

            // Domain Services - Điện tử & Biến Áp & Khởi Động Từ
            services.AddTransient<IDanhmucRoleService, DanhmucRoleService>();
            services.AddTransient<ITonghopRoleService, TonghopRoleService>();
            services.AddTransient<IDanhmucBienApService, DanhmucBienApService>();
            services.AddTransient<IThongsobienapService, ThongsobienapService>();
            services.AddTransient<ITonghopbienapService, TonghopbienapService>();
            services.AddTransient<IDanhmucAptomatKhoidongtuService, DanhmucAptomatKhoidongtuService>();
            services.AddTransient<IThongsoAptomatKhoidongtuService, ThongsoAptomatKhoidongtuService>();
            services.AddTransient<INhatkyaptomatkhoidongtuService, NhatkyaptomatkhoidongtuService>();
            services.AddTransient<ITonghopaptomatkhoidongtuService, TonghopaptomatkhoidongtuService>();

            // Domain Services - Giá Cột
            services.AddTransient<IDanhmucgiacotthuylucService, DanhmucgiacotthuylucService>();
            services.AddTransient<ITonghopgiacotthuylucService, TonghopgiacotthuylucService>();
            services.AddTransient<IDanhmucgiacotService, DanhmucgiacotService>();
            services.AddTransient<ICapnhatgiacotService, CapnhatgiacotService>();

            return services;
        }
    }
}