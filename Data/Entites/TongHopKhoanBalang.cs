using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopKhoanBalang")]
    public class TongHopKhoanBalang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int KhoanBalangId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public string? TinhTrangKyThuat { get; set; }
        public string? LoaiThietBi { get; set; }
        public Boolean DuPhong { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("KhoanBalangId")]
        public virtual DanhmucKhoanBalang? DanhmucKhoanBalang { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? DonVi { get; set; }
    }
}