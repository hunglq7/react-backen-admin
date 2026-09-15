namespace WebApi.Models.Danhmucbangtai
{
    public class ThongsokythuatbangtaiVM
    {
        public int Id { get; set; }
        public int BangTaiId { get; set; }
        public string? TenThietBi { get; set; }
        public string? NoiDung { get; set; }
        public string? DonViTinh { get; set; }
        public string? ThongSo { get; set; }
        public string? GhiChu { get; set; }
    }
}