using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("LoaiThietBi")]
    public class LoaiThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required]
        [MaxLength(100)]
        public string? TenLoai{ get; set; }
        public bool TrangThai { get; set; }
        public virtual IEnumerable<TongHopThietBi>? TongHopThietBis { get; set; }
        public virtual IEnumerable<TongHopMayXuc>? TongHopMayXucs { set; get; }
        public virtual IEnumerable<TonghopCamera>? TonghopCameras { get; set; }
       
    }
}
