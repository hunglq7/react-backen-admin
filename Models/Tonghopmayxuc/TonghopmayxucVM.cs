using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Tonghopmayxuc
{
    public class TonghopmayxucVM
    {

        public int Id { get; set; }
        public string? MaQuanLy { get; set; } 
        public string? TenMayXuc { get; set; }
        public int MayxucId { get; set; }
        public string? TenPhongBan { get; set; } 
        public int PhongBanId { get; set; }
        public string ?LoaiThietBi { get; set; } 
        public int LoaiThietBiId { get; set; }
        public string ?ViTriLapDat { get; set; } 
        public DateTime NgayLap { get; set; }
        public string ?TinhTrang { get; set; } 
        public int SoLuong { get; set; }
        public string? GhiChu { get; set; } 
        public bool DuPhong { get; set; }
        public int TongTB { get; set; }
    }
}
