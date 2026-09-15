using Api.Data.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopToiTruc")]
    public class TongHopToiTruc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? MaQuanLy { get; set; }
        public int ThietbiId { get; set; }       
        public int DonViSuDungId { get; set; }
        [MaxLength (200)]
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        [MaxLength(200)]
        public string?  MucDichSuDung { get; set; }
        public int SoLuong { get; set; }
        [MaxLength(500)]
        public string? TinhTrangThietBi { get; set; }
        public bool DuPhong { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        [ForeignKey("ThietbiId")]
        public virtual  Danhmuctoitruc? Danhmuctoitruc { get; set; }
        [ForeignKey("DonViSuDungId")]
        public virtual PhongBan? PhongBan { get; set; }

        public virtual IEnumerable<NhatkyTonghoptoitruc>? NhatkyTonghoptoitrucs { get; set; }

    }
}
