using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TonghopQuatgio")]
    public class TonghopQuatgio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20)]
        public string? MaQuanLy { get; set; }
        public int QuatGioId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        [MaxLength(500)]
        public string? TinhTrangThietBi { get; set; }
        public bool DuPhong { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        [ForeignKey("QuatGioId")]
        public virtual DanhmucQuatgio? DanhmucQuatgio { get;set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
        public virtual IEnumerable<NhatKyQuatGio>? NhatKyQuatGios { get; set; }
    }
}
