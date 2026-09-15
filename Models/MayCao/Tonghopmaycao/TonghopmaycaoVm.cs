namespace WebApi.Models.MayCao.Tonghopmaycao
{
    public class TonghopmaycaoVm
    {
        public int Id { get; set; }
        public string? MaQuanLy { get; set; }
        public int MayCaoId { get; set; }
        public string? TenThietBi { get; set; }
        public int DonViId { get; set; }
        public string? TenDonVi { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public double ChieuDaiMay { get; set; }
        public int SoLuongXich { get; set; }
        public int SoLuongCauMang { get; set; }
        public string? TinhTrangThietBi { get; set; }
        public Boolean duPhong { get; set; }
        public string? GhiChu { get; set; }
    }
}