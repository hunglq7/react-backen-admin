using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("PhieuNhap")]
    public class PhieuNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "nchar")]
        public String? MaPhieuNhap { get; set; }
        public bool TrangThai { get; set; }

        public DateTime NgayNhap { get; set; }
        public virtual IEnumerable<ChiTietPhieuNhap>? ChiTietPhieuNhaps { get; set; }
    }
}
