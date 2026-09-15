namespace WebApi.Models.Bienap.Thongsokythuatbienap
{
    public class ThongsoBienapVm
    {
        public int Id { get; set; }
        public string? TenThietBi { get; set; }
        public string NoiDung { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public string ThongSo { get; set; } = string.Empty;
    }
}