using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("NhatKyNeo")]
    public class NhatKyNeo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TongHopNeoId { get; set; }
        public string? NgayThang { get; set; }
        [MaxLength(100)]
        public string? DonVi { get; set; } 
        [MaxLength(500)]
        public string? ViTri { get; set; } 
        [MaxLength(500)]
        public string? TrangThai { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; } 
        [ForeignKey("TongHopNeoId")]
        public virtual TongHopNeo? TongHopNeo { get; set; }
    }
}