using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class xuatnhapvattus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_XuatNhapVatTus_ThietBis_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "ThietBis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XuatNhapVatTus_ViTris_ViTriId",
                        column: x => x.ViTriId,
                        principalTable: "ViTris",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "548cd968-386b-4c22-b488-b96be9e7090c", "AQAAAAIAAYagAAAAEMfwwDxhUUz8MpWKqDXFk2OJ0I0+D7f/SmE1vA8xiR3WBKcAWifuaU4KMKKY5V6TOQ==" });

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
                name: "XuatNhapVatTus");

            migrationBuilder.DropTable(
                name: "ThietBis");

            migrationBuilder.DropTable(
                name: "ViTris");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6cf00eaf-8911-4b5b-a13c-6b05221fd79d", "AQAAAAIAAYagAAAAEGLt4SU6njKxAlw2kk0EJ5v0OI61P2omIO58xvdtvtDCc4HNFBQJY/cIrSkXLEuW6A==" });
        }
    }
}
