namespace WebApi.Models.ThongsokythuatMayXuc
{
    public class ThongsokythuatEdit
    {
        public int Id { get; set; }
        public int MayXucId { get; set; }
        public string NoiDung { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public string ThongSo { get; set; } = string.Empty;
    }
}
