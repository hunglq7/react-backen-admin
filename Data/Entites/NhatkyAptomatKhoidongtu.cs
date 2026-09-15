using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    [Table("Nhatkyaptomatkhoidongtu")]
    public class Nhatkyaptomatkhoidongtu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TonghopaptomatkhoidongtuId { get; set; }
        public string? NgayThang { get; set; } 
        [MaxLength(100)]
        public string? DonVi { get; set; } 
        [MaxLength(500)]
        public string? ViTri { get; set; } 
        [MaxLength(500)]
        public string? TrangThai { get; set; } 
        [MaxLength(500)]
        public string? GhiChu { get; set; } 
        [ForeignKey("TonghopaptomatkhoidongtuId")]
        public virtual TongHopAptomatKhoidongtu? TongHopAptomatKhoidongtu { get; set; }
    }
}