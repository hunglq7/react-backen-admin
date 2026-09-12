using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThongSoKyThuat = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    NuocSanXuat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HangSanXuat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NamSanXuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capdien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenthietbi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capdien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucAptomatKhoidongtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucAptomatKhoidongtu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucBalang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucBalang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucBangTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucBangTai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucBienap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucBienap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucBomnuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucBomnuoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucGiaCot",
                columns: table => new
                {
                    LoaiThietBiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucGiaCot", x => x.LoaiThietBiId);
                });

            migrationBuilder.CreateTable(
                name: "Danhmucgiacotthuyluc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmucgiacotthuyluc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucKhoanBalang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKhoanBalang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucMayCao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucNeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucNeo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhmucQuatgio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucQuatgio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Danhmuctoitruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NamSanXuat = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    HangSanXuat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmuctoitruc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonViTinh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDonViTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThietBi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThietBi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MayXuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTaiSan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NamSanXuat = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    HangSanXuat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MayXuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuNhap = table.Column<string>(type: "nchar(6)", maxLength: 6, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuXuat = table.Column<string>(type: "nchar(6)", maxLength: 6, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NgayXuat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThietBis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HangSanXuat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBaoHanh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToiTruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaHieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NuocSX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HangSX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NamSX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CongSuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DienAp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoVongQuay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LucKeo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TocDoKeoCham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TocDoKeoNhanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrongLuongToi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KichThuocNgoaiHinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DuongKinhCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChieuDaiCapQuan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApLucKhiNen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LuongKhiNenTieuHao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToiTruc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VatTu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVatTu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViTris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenViTri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTris", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongsoAptomatKhoidongtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanhmucaptomatKhoidongtuId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsoAptomatKhoidongtu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsoAptomatKhoidongtu_DanhmucAptomatKhoidongtu_DanhmucaptomatKhoidongtuId",
                        column: x => x.DanhmucaptomatKhoidongtuId,
                        principalTable: "DanhmucAptomatKhoidongtu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoKyThuatBangTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BangTaiId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuatBangTai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatBangTai_DanhMucBangTai_BangTaiId",
                        column: x => x.BangTaiId,
                        principalTable: "DanhMucBangTai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoKyThuatBienAp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BienApId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuatBienAp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatBienAp_DanhmucBienap_BienApId",
                        column: x => x.BienApId,
                        principalTable: "DanhmucBienap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoBomNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BomNuocId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoBomNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoBomNuoc_DanhmucBomnuoc_BomNuocId",
                        column: x => x.BomNuocId,
                        principalTable: "DanhmucBomnuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoNeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeoId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoNeo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoNeo_DanhmucNeo_NeoId",
                        column: x => x.NeoId,
                        principalTable: "DanhmucNeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongsoQuatgio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuatgioId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsoQuatgio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsoQuatgio_DanhmucQuatgio_QuatgioId",
                        column: x => x.QuatgioId,
                        principalTable: "DanhmucQuatgio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongsokythuatToitruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanhmuctoitrucId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsokythuatToitruc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsokythuatToitruc_Danhmuctoitruc_DanhmuctoitrucId",
                        column: x => x.DanhmuctoitrucId,
                        principalTable: "Danhmuctoitruc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongsokythuatMayxuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MayXucId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsokythuatMayxuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsokythuatMayxuc_MayXuc_MayXucId",
                        column: x => x.MayXucId,
                        principalTable: "MayXuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CapNhatGiaCot",
                columns: table => new
                {
                    CapNhatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    LoaiThietBiId = table.Column<int>(type: "int", nullable: false),
                    SoLuongDangQuanLy = table.Column<int>(type: "int", nullable: false),
                    ViTriSuDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapNhatGiaCot", x => x.CapNhatId);
                    table.ForeignKey(
                        name: "FK_CapNhatGiaCot_DanhmucGiaCot_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "DanhmucGiaCot",
                        principalColumn: "LoaiThietBiId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CapNhatGiaCot_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoThe = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ChucVuId = table.Column<int>(type: "int", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_ChucVuId",
                        column: x => x.ChucVuId,
                        principalTable: "ChucVu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopAptomatKhoidongtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aptomatkhoidongtuId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayKiemDinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NamSanXuat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DienApSuDung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Idm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DienApDieuKhien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CheDoLamViec = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThongGio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoiDat = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    KheHoPhongNo = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    NapMoNhanh = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    TayDao = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    BitCoCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CapPhongNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopAptomatKhoidongtu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_aptomatkhoidongtuId",
                        column: x => x.aptomatkhoidongtuId,
                        principalTable: "DanhmucAptomatKhoidongtu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopAptomatKhoidongtu_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TonghopBalang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaLangId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangKyThuat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonghopBalang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TonghopBalang_DanhmucBalang_BaLangId",
                        column: x => x.BaLangId,
                        principalTable: "DanhmucBalang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TonghopBalang_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopBangTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BangTaiId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nmay = table.Column<int>(type: "int", nullable: false),
                    Lmay = table.Column<int>(type: "int", nullable: false),
                    KhungDau = table.Column<int>(type: "int", nullable: false),
                    KhungDuoi = table.Column<int>(type: "int", nullable: false),
                    KhungBangRoi = table.Column<int>(type: "int", nullable: false),
                    DayBang = table.Column<int>(type: "int", nullable: false),
                    ConLan = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopBangTai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopBangTai_DanhMucBangTai_BangTaiId",
                        column: x => x.BangTaiId,
                        principalTable: "DanhMucBangTai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopBangTai_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TonghopBienap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BienapId = table.Column<int>(type: "int", nullable: false),
                    PhongbanId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonghopBienap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TonghopBienap_DanhmucBienap_BienapId",
                        column: x => x.BienapId,
                        principalTable: "DanhmucBienap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TonghopBienap_PhongBan_PhongbanId",
                        column: x => x.PhongbanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopBomNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BomNuocId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DuPhong = table.Column<bool>(type: "bit", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopBomNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopBomNuoc_DanhmucBomnuoc_BomNuocId",
                        column: x => x.BomNuocId,
                        principalTable: "DanhmucBomnuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopBomNuoc_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TonghopCamera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenThietBiId = table.Column<int>(type: "int", nullable: false),
                    LoaiThietBiId = table.Column<int>(type: "int", nullable: false),
                    DiaChiIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonViQuanLyId = table.Column<int>(type: "int", nullable: false),
                    KhuVucLapDat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonghopCamera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TonghopCamera_Camera_TenThietBiId",
                        column: x => x.TenThietBiId,
                        principalTable: "Camera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TonghopCamera_DonViTinh_DonViTinhId",
                        column: x => x.DonViTinhId,
                        principalTable: "DonViTinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TonghopCamera_LoaiThietBi_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "LoaiThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TonghopCamera_PhongBan_DonViQuanLyId",
                        column: x => x.DonViQuanLyId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tonghopcapdien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maquanly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonviId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapdienId = table.Column<int>(type: "int", nullable: false),
                    Donvitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tondauthang = table.Column<int>(type: "int", nullable: false),
                    Nhaptrongky = table.Column<int>(type: "int", nullable: false),
                    Xuattrongky = table.Column<int>(type: "int", nullable: false),
                    Toncuoithang = table.Column<int>(type: "int", nullable: false),
                    Dangsudung = table.Column<int>(type: "int", nullable: false),
                    Duphong = table.Column<int>(type: "int", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tonghopcapdien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tonghopcapdien_Capdien_CapdienId",
                        column: x => x.CapdienId,
                        principalTable: "Capdien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tonghopcapdien_PhongBan_DonviId",
                        column: x => x.DonviId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tonghopgiacotthuyluc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThietBiId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    duPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tonghopgiacotthuyluc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tonghopgiacotthuyluc_Danhmucgiacotthuyluc_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "Danhmucgiacotthuyluc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tonghopgiacotthuyluc_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoanId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TinhTrangKyThuat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    duPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopKhoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopKhoan_DanhMucKhoan_KhoanId",
                        column: x => x.KhoanId,
                        principalTable: "DanhMucKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopKhoan_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopKhoanBalang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoanBalangId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangKyThuat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopKhoanBalang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopKhoanBalang_DanhMucKhoanBalang_KhoanBalangId",
                        column: x => x.KhoanBalangId,
                        principalTable: "DanhMucKhoanBalang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopKhoanBalang_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MayCaoId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ChieuDaiMay = table.Column<double>(type: "float", nullable: false),
                    SoLuongXich = table.Column<int>(type: "int", nullable: false),
                    SoLuongCauMang = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    duPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopMayCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopMayCao_DanhmucMayCao_MayCaoId",
                        column: x => x.MayCaoId,
                        principalTable: "DanhmucMayCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopMayCao_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopMayXuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MayXucId = table.Column<int>(type: "int", nullable: false),
                    MaQuanLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoaiThietBiId = table.Column<int>(type: "int", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopMayXuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopMayXuc_LoaiThietBi_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "LoaiThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopMayXuc_MayXuc_MayXucId",
                        column: x => x.MayXucId,
                        principalTable: "MayXuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopMayXuc_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopNeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeoId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TinhTrangKyThuat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    duPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopNeo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopNeo_DanhmucNeo_NeoId",
                        column: x => x.NeoId,
                        principalTable: "DanhmucNeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopNeo_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TonghopQuatgio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    QuatGioId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonghopQuatgio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TonghopQuatgio_DanhmucQuatgio_QuatGioId",
                        column: x => x.QuatGioId,
                        principalTable: "DanhmucQuatgio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TonghopQuatgio_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopRole_DanhMucRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "DanhMucRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopRole_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopToiTruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThietbiId = table.Column<int>(type: "int", nullable: false),
                    DonViSuDungId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MucDichSuDung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ToiTrucId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopToiTruc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopToiTruc_Danhmuctoitruc_ThietbiId",
                        column: x => x.ThietbiId,
                        principalTable: "Danhmuctoitruc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopToiTruc_PhongBan_DonViSuDungId",
                        column: x => x.DonViSuDungId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopToiTruc_ToiTruc_ToiTrucId",
                        column: x => x.ToiTrucId,
                        principalTable: "ToiTruc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhap",
                columns: table => new
                {
                    PhieuNhapId = table.Column<int>(type: "int", nullable: false),
                    VatTuId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false),
                    SoLuongNhap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhap", x => new { x.PhieuNhapId, x.VatTuId });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_DonViTinh_DonViTinhId",
                        column: x => x.DonViTinhId,
                        principalTable: "DonViTinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_PhieuNhap_PhieuNhapId",
                        column: x => x.PhieuNhapId,
                        principalTable: "PhieuNhap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_VatTu_VatTuId",
                        column: x => x.VatTuId,
                        principalTable: "VatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuXuat",
                columns: table => new
                {
                    PhieuXuatId = table.Column<int>(type: "int", nullable: false),
                    VatTuId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuXuat", x => new { x.PhieuXuatId, x.VatTuId });
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_DonViTinh_DonViTinhId",
                        column: x => x.DonViTinhId,
                        principalTable: "DonViTinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_PhieuXuat_PhieuXuatId",
                        column: x => x.PhieuXuatId,
                        principalTable: "PhieuXuat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_VatTu_VatTuId",
                        column: x => x.VatTuId,
                        principalTable: "VatTu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "XuatNhapVatTus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThietBiId = table.Column<int>(type: "int", nullable: false),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: true),
                    ViTriId = table.Column<int>(type: "int", nullable: true),
                    NgayBatDauBaoHanh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatNhapVatTus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XuatNhapVatTus_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XuatNhapVatTus_ThietBis_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XuatNhapVatTus_ViTris_ViTriId",
                        column: x => x.ViTriId,
                        principalTable: "ViTris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhanvienImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanvienImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanvienImage_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TongHopThietBi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaThietBi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    LoaiThietBiId = table.Column<int>(type: "int", nullable: false),
                    NgaySuDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopThietBi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopThietBi_DonViTinh_DonViTinhId",
                        column: x => x.DonViTinhId,
                        principalTable: "DonViTinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopThietBi_LoaiThietBi_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "LoaiThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopThietBi_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TongHopThietBi_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nhatkyaptomatkhoidongtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonghopaptomatkhoidongtuId = table.Column<int>(type: "int", nullable: false),
                    NgayThang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThongsoAptomatKhoidongtuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhatkyaptomatkhoidongtu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nhatkyaptomatkhoidongtu_ThongsoAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                        column: x => x.ThongsoAptomatKhoidongtuId,
                        principalTable: "ThongsoAptomatKhoidongtu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nhatkyaptomatkhoidongtu_TongHopAptomatKhoidongtu_TonghopaptomatkhoidongtuId",
                        column: x => x.TonghopaptomatkhoidongtuId,
                        principalTable: "TongHopAptomatKhoidongtu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyBangTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongHopBangTaiId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyBangTai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyBangTai_TongHopBangTai_TongHopBangTaiId",
                        column: x => x.TongHopBangTaiId,
                        principalTable: "TongHopBangTai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyBomNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongHopBomNuocId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyBomNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyBomNuoc_TongHopBomNuoc_TongHopBomNuocId",
                        column: x => x.TongHopBomNuocId,
                        principalTable: "TongHopBomNuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatkyCamera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraId = table.Column<int>(type: "int", nullable: false),
                    NgayThang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViQuanLyId = table.Column<int>(type: "int", nullable: false),
                    ViTriSuDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatkyCamera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatkyCamera_PhongBan_DonViQuanLyId",
                        column: x => x.DonViQuanLyId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NhatkyCamera_TonghopCamera_CameraId",
                        column: x => x.CameraId,
                        principalTable: "TonghopCamera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongHopMayCaoId = table.Column<int>(type: "int", nullable: false),
                    NgayThang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyMayCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyMayCao_TongHopMayCao_TongHopMayCaoId",
                        column: x => x.TongHopMayCaoId,
                        principalTable: "TongHopMayCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatkyMayxuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonghopmayxucId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatkyMayxuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatkyMayxuc_TongHopMayXuc_TonghopmayxucId",
                        column: x => x.TonghopmayxucId,
                        principalTable: "TongHopMayXuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyQuatGio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonghopquatgioId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyQuatGio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyQuatGio_TonghopQuatgio_TonghopquatgioId",
                        column: x => x.TonghopquatgioId,
                        principalTable: "TonghopQuatgio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NhatkyTonghoptoitruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonghoptoitrucId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatkyTonghoptoitruc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatkyTonghoptoitruc_TongHopToiTruc_TonghoptoitrucId",
                        column: x => x.TonghoptoitrucId,
                        principalTable: "TongHopToiTruc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TheoDoiSuaChua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongHopThietBiId = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    NgaySuDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    NhanVienId = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NguyenNhan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BienPhap = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThayThe = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayThay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoDoiSuaChua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheoDoiSuaChua_NhanVien_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheoDoiSuaChua_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TheoDoiSuaChua_TongHopThietBi_TongHopThietBiId",
                        column: x => x.TongHopThietBiId,
                        principalTable: "TongHopThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoKyThuatMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MayCaoId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhatKyMayCaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuatMayCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatMayCao_DanhmucMayCao_MayCaoId",
                        column: x => x.MayCaoId,
                        principalTable: "DanhmucMayCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatMayCao_NhatKyMayCao_NhatKyMayCaoId",
                        column: x => x.NhatKyMayCaoId,
                        principalTable: "NhatKyMayCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "static-admin-role-concurrency-stamp", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "FullName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, "static-admin-user-concurrency-stamp", new DateTime(1979, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "hunglq7@gmail.com", true, "Hùng", "Lê Quang Hùng", "Lê", false, null, "hunglq7@gmail.com", "admin", "AQAAAAIAAYagAAAAEASnD4B6vtzojn8VQQSRAc5WpLbaxBGhYIfoggNxDV9XJTb1LAHhfQPUBbNWc5mUgg==", null, false, "static-admin-security-stamp", false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CapNhatGiaCot_DonViId",
                table: "CapNhatGiaCot",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_CapNhatGiaCot_LoaiThietBiId",
                table: "CapNhatGiaCot",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_DonViTinhId",
                table: "ChiTietPhieuNhap",
                column: "DonViTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_VatTuId",
                table: "ChiTietPhieuNhap",
                column: "VatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_DonViTinhId",
                table: "ChiTietPhieuXuat",
                column: "DonViTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_VatTuId",
                table: "ChiTietPhieuXuat",
                column: "VatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_ChucVuId",
                table: "NhanVien",
                column: "ChucVuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_PhongBanId",
                table: "NhanVien",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanvienImage_NhanVienId",
                table: "NhanvienImage",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_Nhatkyaptomatkhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "Nhatkyaptomatkhoidongtu",
                column: "ThongsoAptomatKhoidongtuId");

            migrationBuilder.CreateIndex(
                name: "IX_Nhatkyaptomatkhoidongtu_TonghopaptomatkhoidongtuId",
                table: "Nhatkyaptomatkhoidongtu",
                column: "TonghopaptomatkhoidongtuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyBangTai_TongHopBangTaiId",
                table: "NhatKyBangTai",
                column: "TongHopBangTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyBomNuoc_TongHopBomNuocId",
                table: "NhatKyBomNuoc",
                column: "TongHopBomNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyCamera_CameraId",
                table: "NhatkyCamera",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyCamera_DonViQuanLyId",
                table: "NhatkyCamera",
                column: "DonViQuanLyId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyMayCao_TongHopMayCaoId",
                table: "NhatKyMayCao",
                column: "TongHopMayCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyMayxuc_TonghopmayxucId",
                table: "NhatkyMayxuc",
                column: "TonghopmayxucId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyQuatGio_TonghopquatgioId",
                table: "NhatKyQuatGio",
                column: "TonghopquatgioId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyTonghoptoitruc_TonghoptoitrucId",
                table: "NhatkyTonghoptoitruc",
                column: "TonghoptoitrucId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RefreshToken",
                table: "Sessions",
                column: "RefreshToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TheoDoiSuaChua_NhanVienId",
                table: "TheoDoiSuaChua",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TheoDoiSuaChua_PhongBanId",
                table: "TheoDoiSuaChua",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_TheoDoiSuaChua_TongHopThietBiId",
                table: "TheoDoiSuaChua",
                column: "TongHopThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongsoAptomatKhoidongtu_DanhmucaptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                column: "DanhmucaptomatKhoidongtuId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoBomNuoc_BomNuocId",
                table: "ThongSoBomNuoc",
                column: "BomNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatBangTai_BangTaiId",
                table: "ThongSoKyThuatBangTai",
                column: "BangTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatBienAp_BienApId",
                table: "ThongSoKyThuatBienAp",
                column: "BienApId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatMayCao_MayCaoId",
                table: "ThongSoKyThuatMayCao",
                column: "MayCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatMayCao_NhatKyMayCaoId",
                table: "ThongSoKyThuatMayCao",
                column: "NhatKyMayCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongsokythuatMayxuc_MayXucId",
                table: "ThongsokythuatMayxuc",
                column: "MayXucId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongsokythuatToitruc_DanhmuctoitrucId",
                table: "ThongsokythuatToitruc",
                column: "DanhmuctoitrucId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoNeo_NeoId",
                table: "ThongSoNeo",
                column: "NeoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongsoQuatgio_QuatgioId",
                table: "ThongsoQuatgio",
                column: "QuatgioId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopAptomatKhoidongtu_aptomatkhoidongtuId",
                table: "TongHopAptomatKhoidongtu",
                column: "aptomatkhoidongtuId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopAptomatKhoidongtu_DonViId",
                table: "TongHopAptomatKhoidongtu",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopBalang_BaLangId",
                table: "TonghopBalang",
                column: "BaLangId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopBalang_DonViId",
                table: "TonghopBalang",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBangTai_BangTaiId",
                table: "TongHopBangTai",
                column: "BangTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBangTai_DonViId",
                table: "TongHopBangTai",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopBienap_BienapId",
                table: "TonghopBienap",
                column: "BienapId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopBienap_PhongbanId",
                table: "TonghopBienap",
                column: "PhongbanId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBomNuoc_BomNuocId",
                table: "TongHopBomNuoc",
                column: "BomNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBomNuoc_DonViId",
                table: "TongHopBomNuoc",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopCamera_DonViQuanLyId",
                table: "TonghopCamera",
                column: "DonViQuanLyId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopCamera_DonViTinhId",
                table: "TonghopCamera",
                column: "DonViTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopCamera_LoaiThietBiId",
                table: "TonghopCamera",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopCamera_TenThietBiId",
                table: "TonghopCamera",
                column: "TenThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopcapdien_CapdienId",
                table: "Tonghopcapdien",
                column: "CapdienId");

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopcapdien_DonviId",
                table: "Tonghopcapdien",
                column: "DonviId");

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopgiacotthuyluc_DonViId",
                table: "Tonghopgiacotthuyluc",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopgiacotthuyluc_ThietBiId",
                table: "Tonghopgiacotthuyluc",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopKhoan_DonViId",
                table: "TongHopKhoan",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopKhoan_KhoanId",
                table: "TongHopKhoan",
                column: "KhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopKhoanBalang_DonViId",
                table: "TongHopKhoanBalang",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopKhoanBalang_KhoanBalangId",
                table: "TongHopKhoanBalang",
                column: "KhoanBalangId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayCao_DonViId",
                table: "TongHopMayCao",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayCao_MayCaoId",
                table: "TongHopMayCao",
                column: "MayCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayXuc_LoaiThietBiId",
                table: "TongHopMayXuc",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayXuc_MayXucId",
                table: "TongHopMayXuc",
                column: "MayXucId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayXuc_PhongBanId",
                table: "TongHopMayXuc",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopNeo_DonViId",
                table: "TongHopNeo",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopNeo_NeoId",
                table: "TongHopNeo",
                column: "NeoId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopQuatgio_DonViId",
                table: "TonghopQuatgio",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TonghopQuatgio_QuatGioId",
                table: "TonghopQuatgio",
                column: "QuatGioId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopRole_PhongBanId",
                table: "TongHopRole",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopRole_RoleId",
                table: "TongHopRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopThietBi_DonViTinhId",
                table: "TongHopThietBi",
                column: "DonViTinhId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopThietBi_LoaiThietBiId",
                table: "TongHopThietBi",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopThietBi_NhanVienId",
                table: "TongHopThietBi",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopThietBi_PhongBanId",
                table: "TongHopThietBi",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopToiTruc_DonViSuDungId",
                table: "TongHopToiTruc",
                column: "DonViSuDungId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopToiTruc_ThietbiId",
                table: "TongHopToiTruc",
                column: "ThietbiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopToiTruc_ToiTrucId",
                table: "TongHopToiTruc",
                column: "ToiTrucId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_XuatNhapVatTus_DonViId",
                table: "XuatNhapVatTus",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_XuatNhapVatTus_ThietBiId",
                table: "XuatNhapVatTus",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_XuatNhapVatTus_ViTriId",
                table: "XuatNhapVatTus",
                column: "ViTriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "CapNhatGiaCot");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhap");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuXuat");

            migrationBuilder.DropTable(
                name: "NhanvienImage");

            migrationBuilder.DropTable(
                name: "Nhatkyaptomatkhoidongtu");

            migrationBuilder.DropTable(
                name: "NhatKyBangTai");

            migrationBuilder.DropTable(
                name: "NhatKyBomNuoc");

            migrationBuilder.DropTable(
                name: "NhatkyCamera");

            migrationBuilder.DropTable(
                name: "NhatkyMayxuc");

            migrationBuilder.DropTable(
                name: "NhatKyQuatGio");

            migrationBuilder.DropTable(
                name: "NhatkyTonghoptoitruc");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "TheoDoiSuaChua");

            migrationBuilder.DropTable(
                name: "ThongSoBomNuoc");

            migrationBuilder.DropTable(
                name: "ThongSoKyThuatBangTai");

            migrationBuilder.DropTable(
                name: "ThongSoKyThuatBienAp");

            migrationBuilder.DropTable(
                name: "ThongSoKyThuatMayCao");

            migrationBuilder.DropTable(
                name: "ThongsokythuatMayxuc");

            migrationBuilder.DropTable(
                name: "ThongsokythuatToitruc");

            migrationBuilder.DropTable(
                name: "ThongSoNeo");

            migrationBuilder.DropTable(
                name: "ThongsoQuatgio");

            migrationBuilder.DropTable(
                name: "TonghopBalang");

            migrationBuilder.DropTable(
                name: "TonghopBienap");

            migrationBuilder.DropTable(
                name: "Tonghopcapdien");

            migrationBuilder.DropTable(
                name: "Tonghopgiacotthuyluc");

            migrationBuilder.DropTable(
                name: "TongHopKhoan");

            migrationBuilder.DropTable(
                name: "TongHopKhoanBalang");

            migrationBuilder.DropTable(
                name: "TongHopNeo");

            migrationBuilder.DropTable(
                name: "TongHopRole");

            migrationBuilder.DropTable(
                name: "XuatNhapVatTus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "DanhmucGiaCot");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "PhieuXuat");

            migrationBuilder.DropTable(
                name: "VatTu");

            migrationBuilder.DropTable(
                name: "ThongsoAptomatKhoidongtu");

            migrationBuilder.DropTable(
                name: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropTable(
                name: "TongHopBangTai");

            migrationBuilder.DropTable(
                name: "TongHopBomNuoc");

            migrationBuilder.DropTable(
                name: "TonghopCamera");

            migrationBuilder.DropTable(
                name: "TongHopMayXuc");

            migrationBuilder.DropTable(
                name: "TonghopQuatgio");

            migrationBuilder.DropTable(
                name: "TongHopToiTruc");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TongHopThietBi");

            migrationBuilder.DropTable(
                name: "NhatKyMayCao");

            migrationBuilder.DropTable(
                name: "DanhmucBalang");

            migrationBuilder.DropTable(
                name: "DanhmucBienap");

            migrationBuilder.DropTable(
                name: "Capdien");

            migrationBuilder.DropTable(
                name: "Danhmucgiacotthuyluc");

            migrationBuilder.DropTable(
                name: "DanhMucKhoan");

            migrationBuilder.DropTable(
                name: "DanhMucKhoanBalang");

            migrationBuilder.DropTable(
                name: "DanhmucNeo");

            migrationBuilder.DropTable(
                name: "DanhMucRole");

            migrationBuilder.DropTable(
                name: "ThietBis");

            migrationBuilder.DropTable(
                name: "ViTris");

            migrationBuilder.DropTable(
                name: "DanhmucAptomatKhoidongtu");

            migrationBuilder.DropTable(
                name: "DanhMucBangTai");

            migrationBuilder.DropTable(
                name: "DanhmucBomnuoc");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropTable(
                name: "MayXuc");

            migrationBuilder.DropTable(
                name: "DanhmucQuatgio");

            migrationBuilder.DropTable(
                name: "Danhmuctoitruc");

            migrationBuilder.DropTable(
                name: "ToiTruc");

            migrationBuilder.DropTable(
                name: "DonViTinh");

            migrationBuilder.DropTable(
                name: "LoaiThietBi");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "TongHopMayCao");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "DanhmucMayCao");

            migrationBuilder.DropTable(
                name: "PhongBan");
        }
    }
}
