namespace WebApi.Models.NhatkyTonghoptoitruc
{
    public class NhatkyToitrucCreateDto
    {
        public int TonghoptoitrucId { get; set; }

        public string? Ngaythang { get; set; }   // ✅ DateTime

        public string? DonVi { get; set; }
        public string? ViTri { get; set; }

        public string? TrangThai { get; set; }       // ✅ bool

        public string? GhiChu { get; set; }
    }
}
