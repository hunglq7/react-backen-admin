using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhMucBangTai")]
    public class DanhMucBangTai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string? TenThietBi { get; set; }
        public string? GhiChu { get; set; }
        public IEnumerable<ThongSoKyThuatBangTai>? ThongSoKyThuatBangTais { get; set; }
        public IEnumerable<TongHopBangTai>? TongHopBangTais { get; set; }

    }
}