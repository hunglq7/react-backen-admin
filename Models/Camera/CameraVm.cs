using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Camera
{
    public class CameraVm
    {
        public int Id { get; set; } 
        public string TenThietBI { get; set; } = string.Empty;

        public string ThongSoKyThuat { get; set; } = string.Empty;

        public string NuocSanXuat { get; set; } = string.Empty;

        public string HangSanXuat { get; set; } = string.Empty;

        public string NamSanXuat { get; set; } = string.Empty;
     
        public string GhiChu { get; set; } = string.Empty;
    }
}
