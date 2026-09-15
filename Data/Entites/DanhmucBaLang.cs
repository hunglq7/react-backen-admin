using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhmucBalang")]
    public class DanhmucBaLang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? TenThietBi { get; set; }
        [MaxLength(100)]
        public string? LoaiThietBi { get; set; }        
        public String? GhiChu { get; set; }

        public virtual IEnumerable<TonghopBalang>? TonghopBalangs { get; set; }
    }
}
