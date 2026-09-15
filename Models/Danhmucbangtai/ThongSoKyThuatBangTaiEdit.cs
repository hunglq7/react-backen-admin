namespace WebApi.Models.Danhmucbangtai
{
    public class ThongSoKyThuatBangTaiEdit
    {
        public int Id { get; set; }
        public int BangTaiId { get; set; }
        public string? NoiDung { get; set; }
        public string? DonViTinh { get; set; }
        public string? ThongSo { get; set; }
    }
}