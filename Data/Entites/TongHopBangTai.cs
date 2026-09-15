
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Data.Entites
{
    [Table("TongHopBangTai")]
    public class TongHopBangTai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MaHieu { get; set; }
        public int BangTaiId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int Nmay { get; set; }
        public int Lmay { get; set; }
        public int KhungDau { get; set; }
        public int KhungDuoi { get; set; }
        public int KhungBangRoi { get; set; }
        public int DayBang { get; set; }
        public int ConLan { get; set; }
        public string? TinhTrangThietBi { get; set; }
        public Boolean duPhong { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("BangTaiId")]
        public virtual DanhMucBangTai? DanhMucBangTai { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }

    }
}