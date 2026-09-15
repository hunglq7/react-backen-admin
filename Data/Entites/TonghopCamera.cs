using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TonghopCamera")]
    public class TonghopCamera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? MaQuanLy { get; set; }
        public int TenThietBiId { get; set; }
        public int LoaiThietBiId { get; set; }
        [StringLength(50)]
        public string? DiaChiIP { get; set; }
        public int DonViTinhId { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayLap { get; set; }
        public int DonViQuanLyId{ get; set; }
        [StringLength(100)]
        public string? KhuVucLapDat { get; set; }
        [StringLength(200)]
        public string? ViTriLapDat { get; set; } 
        [StringLength(200)]
        public string? TinhTrangThietBi { get; set; }
        [StringLength(500)]
        public string? GhiChu { get; set; } 


        [ForeignKey("TenThietBiId")]
        public virtual Camera? Camera { get; set; }
        [ForeignKey("LoaiThietBiId")]
        public virtual LoaiThietBi? LoaiThietBi { get; set; }
        [ForeignKey("DonViQuanLyId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("DonViTinhId")]
        public virtual DonViTinh? DonViTinh { get; set; }

        public virtual IEnumerable<NhatkyCamera>? NhatkyCameras { get; set; }
    }
}
