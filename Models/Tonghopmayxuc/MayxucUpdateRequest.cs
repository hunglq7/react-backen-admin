namespace WebApi.Models.Tonghopmayxuc
{
    public class MayxucUpdateRequest
    {
        public int Id { get; set; }

        public string? MaQuanLy { get; set; } 
        public int MayXucId { get; set; }
        public int PhongBanId { get; set; }
        public int LoaiThietBiId { get; set; }

        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public string? TinhTrang { get; set; }
        public string? GhiChu { get; set; } 
        public Boolean DuPhong { get; set; } 
    }
}
