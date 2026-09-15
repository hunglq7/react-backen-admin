namespace WebApi.Models.Nhatkymayxuc
{
    public class NhatkyMayxucUpdateDto
    {
        public int Id { get; set; }
        public int TonghopmayxucId { get; set; }

        public string? Ngaythang { get; set; }   // ✅
        public string? TrangThai { get; set; }       // ✅

        public string? DonVi { get; set; }
        public string? ViTri { get; set; }
        public string? GhiChu { get; set; }
    }
}