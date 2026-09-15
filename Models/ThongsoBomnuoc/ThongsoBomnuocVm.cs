using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.ThongsoBomnuoc
{
    public class ThongsoBomnuocVm
    {
        public int Id { get; set; }

        public string? TenThietBi { get; set; }
        public int BomNuocId { get; set; }

        public string NoiDung { get; set; } = string.Empty;

        public string DonViTinh { get; set; } = string.Empty;

        public string ThongSo { get; set; } = string.Empty;
    }
}
