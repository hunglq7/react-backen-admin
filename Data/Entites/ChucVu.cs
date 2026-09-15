using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required]
        [StringLength(100)]
        public string? TenChucVu { get; set; }
        public bool TrangThai { get; set; }
        public virtual IEnumerable<NhanVien>? NhanViens { get; set; }
    }
}
