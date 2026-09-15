using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhmucBomnuoc")]
    public class DanhmucBomnuoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(500)]
        [Required]
        public string? TenThietBi { get; set; }
        [MaxLength(200)]
        public string? LoaiThietBi { get; set; }
        public virtual IEnumerable<ThongSoBomNuoc>? ThongSoBomNuocs { get; set; }
        public virtual IEnumerable<TongHopBomNuoc>? TongHopBomNuocs { get; set; }

    }
}
