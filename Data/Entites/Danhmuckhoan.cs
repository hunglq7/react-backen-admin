using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhMucKhoan")]
    public class DanhMucKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? TenThietBi { get; set; }

    
        [MaxLength(200)]
        public string? LoaiThietBi { get; set; }

        [MaxLength(500)]
        public string? GhiChu { get; set; }
        public virtual IEnumerable<TongHopKhoan>? TongHopKhoans { get; set; }
    }
}