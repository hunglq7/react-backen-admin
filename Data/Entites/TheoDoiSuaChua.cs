using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TheoDoiSuaChua")]
    public class TheoDoiSuaChua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TongHopThietBiId { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgaySuDung { get; set; }
        public int PhongBanId { get; set; }
        public int NhanVienId { get; set; }
        [StringLength(500)]
        public string? TinhTrangThietBi { get; set; }
        [StringLength(500)]
        public string? NguyenNhan { get; set; }
        [StringLength(500)]
        public string? BienPhap { get; set; }
        [StringLength(500)]
        public string? ThayThe { get; set; }
        public DateTime NgayThay { get; set; }
       
        public string? GhiChu { get; set; }
        [ForeignKey("TongHopThietBiId")]
        public virtual TongHopThietBi? TongHopThietBi { get; set; }
        [ForeignKey("PhongBanId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("NhanVienId")]
        public virtual NhanVien? NhanVien { get; set; }
    }
}
