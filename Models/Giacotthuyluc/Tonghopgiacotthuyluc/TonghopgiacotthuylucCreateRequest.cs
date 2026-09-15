namespace WebApi.Models.Giacotthuyluc.Tonghopgiacotthuyluc
{
    public class TonghopgiacotthuylucCreateRequest
    {
        public int Id { get; set; }
        public int ThietBiId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public Boolean duPhong { get; set; }
        public string? GhiChu { get; set; }
    }
}