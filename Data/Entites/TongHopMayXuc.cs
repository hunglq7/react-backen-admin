using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Data.Entites
{
    [Table("TongHopMayXuc")]
    public class TongHopMayXuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MayXucId { get; set; }
        [MaxLength(50)]
        public string? MaQuanLy { get; set; }     
        public int LoaiThietBiId { get; set; }    
        public int PhongBanId { get; set; }
        public string? ViTriLapDat { get; set; }
        public string? TinhTrang { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; } 
        public Boolean DuPhong { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("MayXucId")]
        public virtual MayXuc? MayXuc { get; set; }
        [ForeignKey("PhongBanId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("LoaiThietBiId")]
        public virtual LoaiThietBi? LoaiThietBi { get; set; }
        public virtual IEnumerable<NhatkyMayxuc>? NhatkyMayxucs { get; set; }
    }
}
