
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhMucRole")]
    public class DanhMucRole
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TenThietBi { get; set; }
        [MaxLength(100)]
        public string? LoaiThietBi { get; set; }
        public string? GhiChu { get; set; }
        public virtual IEnumerable<TongHopRole>? TongHopRoles { get; set; }
    }
}
