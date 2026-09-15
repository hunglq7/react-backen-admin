using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Neo.Tonghopneo
{
    public class TonghopneoCreateRequest
    {
        public int Id { get; set; }
        public int NeoId { get; set; }
        public int DonViId { get; set; }  
        public string? DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayLap { get; set; } 
        public string? ViTriLapDat { get; set; }
        public string? TinhTrangKyThuat { get; set; }
        public Boolean duPhong { get; set; }   
        public string? GhiChu { get; set; }
    }
}
