using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.GiaCot
{
    public class DanhmucgiacotVm
    {
        public int LoaiThietBiId { get; set; }
        public string? MaLoai { get; set; }
        public string? TenLoai { get; set; }
        public string? MoTa { get; set; }
    }
}
