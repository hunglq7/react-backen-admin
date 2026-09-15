using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ThongsoQuatgio
{
    public class ThongsoQuatgioVm
    {
        public int Id { get; set; }
        public string? TenThietBi { get; set; }
        public int QuatGioId { get; set; }
        public string NoiDung { get; set; } = string.Empty;

        public string DonViTinh { get; set; } = string.Empty;

        public string ThongSo { get; set; } = string.Empty;
    }
}
