using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TonghopBalang")]
    public class TonghopBalang
    {
        public int Id { get; set; }
        public int BaLangId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public string? DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string? TinhTrangKyThuat { get; set; }
        public Boolean duPhong { get; set; }
        public string? GhiChu { get; set; }

        [ForeignKey("BaLangId")]
        public virtual DanhmucBaLang? DanhmucBaLang { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }

    }
}
