namespace WebApi.Models.Tonghopmayxuc
{
    public class MayxucCreateRequest
    {
        public int Id { get; set; }

        public string MaQuanLy { get; set; } = string.Empty;
        public int MayXucId { get; set; }
        public int PhongBanId { get; set; }
        public int LoaiThietBiId { get; set; }
        public string ViTriLapDat { get; set; } = string.Empty;
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public string TinhTrang { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
        public Boolean DuPhong { get; set; } 
    }
}
