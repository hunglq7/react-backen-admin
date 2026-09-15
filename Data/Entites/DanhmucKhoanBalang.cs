using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhMucKhoanBalang")]
    public class DanhmucKhoanBalang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? TenThietBi { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        public virtual IEnumerable<TongHopKhoanBalang>? TongHopKhoanBalangs { get; set; }
    }
}