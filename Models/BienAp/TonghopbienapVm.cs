using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.BienAp
{
    public class TonghopbienapVm
    {
        public int Id { get; set; }
        public string? TenThietBi { get; set; }
        public int BienapId { get; set; }
        public string? TenPhongBan { get; set; }
        public int PhongbanId { get; set; }
    
        public string? ViTriLapDat { get; set; }
        public DateTime? NgayLap { get; set; }
        public Boolean DuPhong { get; set; }
   
        public string? GhiChu { get; set; }
    }
}
