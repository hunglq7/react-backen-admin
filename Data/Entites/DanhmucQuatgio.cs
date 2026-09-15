using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DanhmucQuatgio")]
    public class DanhmucQuatgio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(500)]
        public string? TenThietBi { get; set; }
        [MaxLength(500)]
        public string? LoaiThietBi { get; set; }       
       public virtual IEnumerable<ThongsoQuatgio>? ThongsoQuatgios { get; set; }
        public virtual IEnumerable<TonghopQuatgio>? TonghopQuatgios { get;set; }
    }
}
