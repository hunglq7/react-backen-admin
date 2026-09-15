namespace WebApi.Models.TonghopBalang
{
    public class TonghopBalangVm
    {
        public int Id { get; set; }
        public string?TenThietBi { get; set; }
        public string?TenDonVi { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public string? DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string? TinhTrangKyThuat { get; set; }
        public Boolean duPhong { get; set; }
        public string? GhiChu { get; set; }
    }
}
