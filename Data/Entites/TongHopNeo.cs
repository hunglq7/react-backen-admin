using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopNeo")]
    public class TongHopNeo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NeoId { get; set; }
        public int DonViId { get; set; }
        [MaxLength(100)]
        public string? DonViTinh { get; set; } 
        public int SoLuong { get; set; }
        public DateTime NgayLap { get; set; }
        [MaxLength(500)]
        public string? ViTriLapDat { get; set; } 
        [MaxLength(500)]
        public string? TinhTrangKyThuat { get; set; } 
        public Boolean duPhong { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; } 

        [ForeignKey("NeoId")]
        public virtual DanhmucNeo? DanhmucNeo { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
    }
}