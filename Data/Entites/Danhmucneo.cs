using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhmucNeo")]
    public class DanhmucNeo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(500)]
        [Required]
        public string? TenThietBi { get; set; }

        [MaxLength(200)]
        public string? LoaiThietBi { get; set; }
        public virtual IEnumerable<ThongsoNeo>? ThongSoNeos { get; set; }
        public virtual IEnumerable<TongHopNeo>? TongHopNeos { get; set; }
    }
}