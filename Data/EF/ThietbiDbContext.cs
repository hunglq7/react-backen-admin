using Api.Data.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entites;
using WebApi.Data.Extentions;


namespace WebApi.Data.EF
{
    public class ThietbiDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ThietbiDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            //Data seeding
            modelBuilder.Seed();
        }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<DonViTinh> DonViTinhs { get; set; }
        public DbSet<LoaiThietBi> LoaiThietBis { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<PhieuXuat> PhieuXuats { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public DbSet<TongHopThietBi> TongHopThietBis { get; set; }
        public DbSet<TheoDoiSuaChua> TheoDoiSuaChuas { get; set; }
        public DbSet<VatTu> VatTus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<NhanvienImage> NhanvienImages { get; set; }
        public DbSet<MayXuc> MayXucs { get; set; }
        public DbSet<TongHopMayXuc> TongHopMayXucs { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<TonghopCamera> TonghopCameras { get; set; }
        public DbSet<NhatkyMayxuc> NhatkyMayxucs { get; set; }
        public DbSet<ThongsokythuatMayxuc> ThongsokythuatMayxucs { get; set; }
        public DbSet<ToiTruc> ToiTrucs { get; set; }
        public DbSet<TongHopToiTruc> TongHopToiTrucs { get; set; }
        public DbSet<NhatkyTonghoptoitruc> NhatkyTonghoptoitrucs { get; set; }
        public DbSet<Danhmuctoitruc> Danhmuctoitrucs { get; set; }
        public DbSet<ThongsokythuatToitruc> ThongsokythuatToitrucs { get; set; }
        public DbSet<Capdien> Capdiens { get; set; }
        public DbSet<Tonghopcapdien> Tonghopcapdiens { get; set; }
        public DbSet<ThongsoQuatgio> ThongsoQuatgios { get; set; }
        public DbSet<DanhmucQuatgio> DanhmucQuatgios { get; set; }
        public DbSet<TonghopQuatgio> TonghopQuatgio { get; set; }
        public DbSet<NhatKyQuatGio> NhatKyQuatGios { get; set; }
        public DbSet<DanhmucBomnuoc> DanhmucBomnuocs { get; set; }
        public DbSet<ThongSoBomNuoc> ThongSoBomNuocs { get; set; }
        public DbSet<NhatKyBomNuoc> NhatKyBomNuocs { get; set; }
        public DbSet<TongHopBomNuoc> TongHopBomNuocs { get; set; }
        public DbSet<DanhmucBaLang> DanhmucBaLangs { get; set; }
        public DbSet<TonghopBalang> TonghopBalangs { get; set; }
        public DbSet<DanhmucBienap> DanhmucBienaps { get; set; }
        public DbSet<DanhMucKhoan> DanhMucKhoans { get; set; }
        public DbSet<TongHopKhoan> TongHopKhoans { get; set; }
        public DbSet<DanhmucMayCao> DanhmucMayCaos { get; set; }
        public DbSet<ThongSoKyThuatMayCao> ThongSoKyThuatMayCaos { get; set; }
        public DbSet<NhatKyMayCao> NhatKyMayCaos { get; set; }
        public DbSet<TongHopMayCao> TongHopMayCaos { get; set; }
        public DbSet<DanhmucNeo> DanhmucNeos { get; set; }
        public DbSet<ThongsoNeo> ThongsoNeos { get; set; }
        public DbSet<TongHopNeo> TongHopNeos { get; set; }
        public DbSet<DanhMucBangTai> DanhMucBangTais { get; set; }
        public DbSet<ThongSoKyThuatBangTai> ThongSoKyThuatBangTais { get; set; }
        public DbSet<ThongSoKyThuatBienAp> ThongSoKyThuatBienAps { get; set; }
        public DbSet<NhatKyBangTai> NhatKyBangTais { get; set; }
        public DbSet<TongHopBangTai> TongHopBangTais { get; set; }
        public DbSet<DanhMucRole> DanhMucRoles { get; set; }
        public DbSet<TongHopRole> TongHopRoles { get; set; }
        public DbSet<DanhmucAptomatKhoidongtu> DanhmucAptomatKhoidongtus { get; set; }
        public DbSet<Danhmucgiacotthuyluc> Danhmucgiacotthuylucs { get; set; }
        public DbSet<Tonghopgiacotthuyluc> Tonghopgiacotthuylucs { get; set; }
        public DbSet<ThongsoAptomatKhoidongtu> ThongsoAptomatKhoidongtus { get; set; }
        public DbSet<TongHopAptomatKhoidongtu> TongHopAptomatKhoidongtus { get; set; }
        public DbSet<Nhatkyaptomatkhoidongtu> Nhatkyaptomatkhoidongtus { get; set; }
        public DbSet<DanhmucGiaCot> DanhmucGiaCots { get; set; }
        public DbSet<CapNhatGiaCot> CapNhatGiaCots { get; set; }
        public DbSet<TonghopBienap> TonghopBienaps { get; set; }
        public DbSet<TongHopKhoanBalang> TongHopKhoanBalangs { get; set; }
        public DbSet<DanhmucKhoanBalang> DanhmucKhoanBalangs { get; set; }
        public DbSet<XuatNhapVatTu> XuatNhapVatTus { get; set; }
        public DbSet<ThietBi> ThietBis { get; set; }
        public DbSet<ViTri> ViTris { get; set; }

    }
}
