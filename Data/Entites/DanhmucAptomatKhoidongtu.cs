using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhmucAptomatKhoidongtu")]
    public class DanhmucAptomatKhoidongtu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? TenThietBi { get; set; }
        [MaxLength(100)]
        public string? LoaiThietBi { get; set; }
        public string? GhiChu { get; set; }
        public virtual IEnumerable<ThongsoAptomatKhoidongtu>? ThongsoAptomatKhoidongtus { get; set; }
        public virtual IEnumerable<TongHopAptomatKhoidongtu>? TongHopAptomatKhoidongtus { get; set; }
    }
}