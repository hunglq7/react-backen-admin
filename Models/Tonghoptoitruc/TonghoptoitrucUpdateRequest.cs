namespace WebApi.Models.Tonghoptoitruc
{
    public class TonghoptoitrucUpdateRequest
    {
        public int Id { get; set; }

        public string? MaQuanLy { get; set; }
        public int ThietbiId { get; set; }
        public int DonViSuDungId { get; set; }

        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }

        public string? MucDichSuDung { get; set; }
        public int SoLuong { get; set; }

        public string? TinhTrangThietBi { get; set; }
        public bool DuPhong { get; set; }

        public string? GhiChu { get; set; }
    }
}
