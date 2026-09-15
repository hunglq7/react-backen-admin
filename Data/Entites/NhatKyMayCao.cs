using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("NhatKyMayCao")]
    public class NhatKyMayCao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TongHopMayCaoId { get; set; }

        public string? NgayThang { get; set; } 

        [MaxLength(100)]
        public string? DonVi { get; set; } 

        [MaxLength(500)]
        public string? ViTri { get; set; } 

        [MaxLength(500)]
        public string? TrangThai { get; set; } 

        [MaxLength(500)]
        public string? GhiChu { get; set; } 

        [ForeignKey("TongHopMayCaoId")]
        public virtual TongHopMayCao? TongHopMayCao { get; set; }
        public virtual IEnumerable<ThongSoKyThuatMayCao>? ThongSoKyThuatMayCaos { get; set; }
    }
}