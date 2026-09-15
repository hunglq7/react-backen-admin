namespace WebApi.Models.Neo.NhatKyNeo
{
    public class NhatKyNeoVm
    {
        public int Id { get; set; }
        public int TongHopNeoId { get; set; }
        public string NgayThang { get; set; } = string.Empty;
        public string DonVi { get; set; } = string.Empty;
        public string ViTri { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}