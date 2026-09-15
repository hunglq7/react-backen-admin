namespace WebApi.Models.Neo.TongHopNeo
{
    public class TongHopNeoVm
    {
        public int Id { get; set; }
        public int NeoId { get; set; }
        public int DonViId { get; set; }
        public string TenThietBi { get; set; } = string.Empty;
        public string TenDonVi { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public DateTime NgayLap { get; set; }
        public string ViTriLapDat { get; set; } = string.Empty;
        public string TinhTrangKyThuat { get; set; } = string.Empty;
        public Boolean duPhong { get; set; }
        public string GhiChu { get; set; } = string.Empty;
    }
}