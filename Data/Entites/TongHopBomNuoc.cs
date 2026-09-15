using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    [Table("TongHopBomNuoc")]
    public class TongHopBomNuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(20)]
        public string? MaQuanLy { get; set; }
        public int BomNuocId { get; set; }
        public int DonViId { get; set; }
        [MaxLength(500)]
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        [MaxLength(500)]
        public string? TinhTrangThietBi { get; set; }
        [MaxLength(500)]
        public Boolean DuPhong { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("BomNuocId")]
        public virtual DanhmucBomnuoc? DanhmucBomnuoc { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
         public virtual IEnumerable<NhatKyBomNuoc>? NhatKyBomNuocs { get; set; }
    }
}
