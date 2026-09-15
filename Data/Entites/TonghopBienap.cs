using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Data.Entites
{
    [Table("TonghopBienap")]
    public class TonghopBienap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BienapId { get; set; }
        public int PhongbanId { get; set; }
        [MaxLength(500)]
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public Boolean DuPhong { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        [ForeignKey("BienapId")]
        public virtual DanhmucBienap? DanhmucBienap { get; set; }
        [ForeignKey("PhongbanId")]
        public virtual PhongBan? PhongBan { get; set; }
    }
}
