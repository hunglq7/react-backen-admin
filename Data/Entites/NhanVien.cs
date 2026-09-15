using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? TenNhanVien { get; set; }

        [StringLength(5)]
        public string? SoThe { set; get; }

        [MaxLength(15)]
        public string? DienThoai { get; set; }

        public DateTime NgaySinh { get; set; }

        [MaxLength(250)]
        public string? DiaChi { get; set; }

        public int PhongBanId { get; set; }
        public int? ChucVuId { get; set; }
        public string? HinhAnh { get; set; }
        public bool TrangThai { get; set; }
        public string? GhiChu { get; set; }

        [ForeignKey(nameof(PhongBanId))]
        public virtual PhongBan? PhongBan { get; set; }

        [ForeignKey(nameof(ChucVuId))]
        public virtual ChucVu? ChucVu { get; set; }
        public virtual IEnumerable<TongHopThietBi>? TongHopThietBis { get; set; }
        public virtual IEnumerable<TheoDoiSuaChua>? TheoDoiSuaChuas { get; set; }
        public virtual IEnumerable<NhanvienImage>? NhanvienImages { get; set; }
    }
}
