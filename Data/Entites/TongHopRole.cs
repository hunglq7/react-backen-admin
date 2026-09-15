using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopRole")]
    public class TongHopRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PhongBanId { get; set; }
        [MaxLength(500)]
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        [MaxLength(100)]
        public string? TinhTrangThietBi { get; set; }
        public Boolean DuPhong { get; set; }      
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        [ForeignKey("RoleId")]
        public virtual DanhMucRole? DanhmucRole { get; set; }
        [ForeignKey("PhongBanId")]
        public virtual PhongBan? PhongBan { get; set; }
    }
}
