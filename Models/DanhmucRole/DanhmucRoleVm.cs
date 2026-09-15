using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.DanhmucRole
{
    public class DanhmucRoleVm
    {
        public int Id { get; set; }
        public string? TenThietBi { get; set; }      
        public string? LoaiThietBi { get; set; }
        public string? GhiChu { get; set; }
    }
}
