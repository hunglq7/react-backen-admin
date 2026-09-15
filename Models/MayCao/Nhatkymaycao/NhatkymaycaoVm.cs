namespace WebApi.Models.MayCao.Nhatkymaycao
{
    public class NhatkymaycaoVm
    {
        public int Id { get; set; }
        public int TonghopmaycaoId { get; set; }
        public string NgayThang { get; set; } = string.Empty;
        public string DonVi { get; set; } = string.Empty;
        public string ViTri { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}