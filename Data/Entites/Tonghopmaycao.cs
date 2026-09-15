using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopMayCao")]
    public class TongHopMayCao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        public string? MaQuanLy { get; set; }

        public int MayCaoId { get; set; }

        public int DonViId { get; set; }

        [MaxLength(500)]
        public string? ViTriLapDat { get; set; }

        public DateTime NgayLap { get; set; }

        public int SoLuong { get; set; }

        public double ChieuDaiMay { get; set; }

        public int SoLuongXich { get; set; }

        public int SoLuongCauMang { get; set; }

        [MaxLength(500)]
        public string? TinhTrangThietBi { get; set; }
        public Boolean duPhong { get; set; }

        [MaxLength(500)]
        public string? GhiChu { get; set; }

        [ForeignKey("MayCaoId")]
        public virtual DanhmucMayCao? DanhmucMayCao { get; set; }

        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }

        public virtual IEnumerable<NhatKyMayCao>? NhatKyMayCaos { get; set; }
    }
}