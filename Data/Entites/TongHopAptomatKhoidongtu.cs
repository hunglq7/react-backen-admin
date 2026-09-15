using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopAptomatKhoidongtu")]
    public class TongHopAptomatKhoidongtu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int aptomatkhoidongtuId { get; set; }
        public int DonViId { get; set; }
        [MaxLength(200)]
        public string? ViTriLapDat { get; set; }
        public DateTime? NgayKiemDinh { get; set; }
        public DateTime? NamSanXuat { get; set; }
        [MaxLength(50)]
        public string? DienApSuDung { get; set; }
        [MaxLength(50)]
        public string? Idm { get; set; }
        [MaxLength(50)]
        public string? DienApDieuKhien { get; set; }
        [MaxLength(50)]
        public string? CheDoLamViec { get; set; }
        [MaxLength(50)]
        public string? ThongGio { get; set; }
        [MaxLength(50)]
        public bool NoiDat { get; set; }
        [MaxLength(50)]
        public bool KheHoPhongNo { get; set; }
        [MaxLength(50)]
        public bool NapMoNhanh { get; set; }
        [MaxLength(50)]
        public bool TayDao { get; set; }
        [MaxLength(50)]
        public string? BitCoCap { get; set; }
        [MaxLength(50)]
        public string? CapPhongNo { get; set; }
        [MaxLength(200)]
        public string? TinhTrangThietBi { get; set; }
        public bool DuPhong { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("aptomatkhoidongtuId")]
        public virtual DanhmucAptomatKhoidongtu? DanhmucAptomatKhoidongtu { get; set; }
        public virtual IEnumerable<Nhatkyaptomatkhoidongtu>? Nhatkyaptomatkhoidongtus { get; set; }

    }
}