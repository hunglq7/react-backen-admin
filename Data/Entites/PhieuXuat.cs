using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    [Table("PhieuXuat")]
    public class PhieuXuat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "nchar")]
        public string? MaPhieuXuat { get; set; }
        public bool TrangThai {  get; set; }
        public DateTime NgayXuat { get; set; }
        public virtual IEnumerable<ChiTietPhieuXuat>? ChiTietPhieuXuats { get; set; }
    }
}
