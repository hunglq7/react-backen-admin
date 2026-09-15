using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("DonViTinh")]
    public class DonViTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [Required]
        [MaxLength(100)]
        public string? TenDonViTinh { get; set; }
        public bool TrangThai { get; set; }
        public virtual IEnumerable<ChiTietPhieuNhap>? ChiTietPhieuNhaps { get; set; }
        public virtual IEnumerable<ChiTietPhieuXuat>? ChiTietPhieuXuats { get; set; }
        public virtual IEnumerable<TongHopThietBi>? TongHopThietBis { get; set; }
        public virtual IEnumerable<TonghopCamera>? TonghopCameras { get; set; }
    }
}
