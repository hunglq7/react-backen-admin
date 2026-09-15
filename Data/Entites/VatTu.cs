using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    [Table("VatTu")]
    public class VatTu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string? TenVatTu { get; set; }
        public bool TrangThai {  get; set; }

        public virtual IEnumerable<ChiTietPhieuNhap>? ChiTietPhieuNhaps { get; set; }
        public virtual IEnumerable<ChiTietPhieuXuat>? ChiTietPhieuXuats { get; set; }
    }
}
