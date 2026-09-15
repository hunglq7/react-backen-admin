using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.TonghopRole
{
    public class TonghopRoleVm
    {
        public int Id { get; set; }
        public string? TenThietBi { get; set; }
        public int RoleId { get; set; }
        public string? TenPhong { get; set; }
        public int PhongBanId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public string? TinhTrangThietBi { get; set; }
        public Boolean DuPhong { get; set; }
        public string? GhiChu { get; set; }
    }
}
