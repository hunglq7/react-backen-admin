using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.TonghopBomnuc
{
    public class TonghopbomnuocCreateRequest
    {
        public int Id { get; set; }
        public string? MaQuanLy { get; set; }
        public int BomNuocId { get; set; }
        public int DonViId { get; set; }    
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }        
        public string? TinhTrangThietBi { get; set; }    
        public Boolean DuPhong { get; set; }
        public string? GhiChu { get; set; }
    }
}
