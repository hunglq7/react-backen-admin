namespace WebApi.Models.ThongsokythuatMayXuc
{
    public class ThongsokythuatmayxucVm
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; } = string.Empty;
        public int MayXucId { get; set; }
        public string NoiDung { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public string ThongSo { get; set; } = string.Empty;
    }
}
