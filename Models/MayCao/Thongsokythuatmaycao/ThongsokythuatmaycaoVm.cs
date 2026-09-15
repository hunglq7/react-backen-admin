namespace WebApi.Models.MayCao.ThongsokythuatMayCao
{
    public class ThongsokythuatmaycaoVm
    {
        public int Id { get; set; }
        public int MayCaoId { get; set; }
        public string TenThietBi { get; set; } = string.Empty;
        public string NoiDung { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public string ThongSo { get; set; } = string.Empty;
    }
}