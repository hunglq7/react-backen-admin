using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhmucGiaCot")]
    public class DanhmucGiaCot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoaiThietBiId { get; set; }
        [Required]
        public string? MaLoai { get; set; }
        [Required]
        public string? TenLoai { get; set; }
        public string? MoTa { get; set; }
        public virtual IEnumerable<CapNhatGiaCot>? CapNhatGiaCots { get; set; }
    }
}
