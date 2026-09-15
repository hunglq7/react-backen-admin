using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhmucMayCao")]
    public class DanhmucMayCao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? TenThietBi { get; set; }

        [MaxLength(100)]
        public string? LoaiThietBi { get; set; }

        public string? GhiChu { get; set; }
        public virtual IEnumerable<ThongSoKyThuatMayCao>? ThongSoKyThuatMayCaos { get; set; }
        public virtual IEnumerable<TongHopMayCao>? TongHopMayCaos { get; set; }
    }
}