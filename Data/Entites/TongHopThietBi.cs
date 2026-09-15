using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopThietBi")]
    public class TongHopThietBi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string? MaThietBi { get; set; }
        public bool TrangThai { get; set; }
        [StringLength(250)]
        public string? HinhAnh { get; set; }
        public string? TenThietBi { get; set; }
        public int DonViTinhId { get; set; }
        public int SoLuong { get; set; }

        public int LoaiThietBiId { get; set; }
        public DateTime NgaySuDung { get; set; }
        public string? TinhTrangThietBi { get; set; }
        public int PhongBanId { get; set; }
        public int NhanVienId { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("DonViTinhId")]
        public virtual DonViTinh? DonViTinh { get; set; }
        [ForeignKey("LoaiThietBiId")]
        public virtual LoaiThietBi? LoaiThietBi { get; set; }
        [ForeignKey("PhongBanId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("NhanVienId")]
        public virtual NhanVien? NhanVien { get; set; }
    }
}
