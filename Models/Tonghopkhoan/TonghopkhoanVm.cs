namespace WebApi.Models.Tonghopkhoan
{
    public class TongHopKhoanVm
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; } = string.Empty;
        public string TenDonVi { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public string ViTriLapDat { get; set; } = string.Empty;
        public string TinhTrangKyThuat { get; set; } = string.Empty;
        public Boolean duPhong { get; set; }
        public string GhiChu { get; set; } = string.Empty;
    }
}