using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.TonghopCamera
{
    public class TonghopCameraVm
    {
        public int Id { get; set; }
    
        public string MaQuanLy { get; set; } = string.Empty;
        public string TenThietBi { get; set; }=string.Empty;
        public string TenLoaiThietBi { get; set; } = string.Empty;
      
        public string DiaChiIP { get; set; } = string.Empty;
        public string TenDonViTinh { get; set; }= string.Empty;
        public int SoLuong { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenDonViQuanLy { get; set; }=string.Empty ;
    
        public string KhuVucLapDat { get; set; } = string.Empty;
    
        public string ViTriLapDat { get; set; } = string.Empty;
    
        public string TinhTrangThietBi { get; set; } = string.Empty;
      
        public string GhiChu { get; set; } = string.Empty;
        public int TongTb { get; set; }
    }
}
