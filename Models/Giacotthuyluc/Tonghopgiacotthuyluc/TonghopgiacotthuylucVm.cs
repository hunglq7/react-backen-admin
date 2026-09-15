namespace WebApi.Models.Giacotthuyluc.Tonghopgiacotthuyluc
{
    public class TonghopgiacotthuylucVm
    {
        public int Id { get; set; }
        public string? TenThietBi { get; set; }
        public string? DonVi { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public Boolean duPhong { get; set; }
        public string? GhiChu { get; set; }
    }
}