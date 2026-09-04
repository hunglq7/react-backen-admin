using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("Tonghopgiacotthuyluc")]
    public class Tonghopgiacotthuyluc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ThietBiId { get; set; }
        public int DonViId { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTime NgayLap { get; set; }
        public int SoLuong { get; set; }
        public Boolean duPhong { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("ThietBiId")]
        public virtual Danhmucgiacotthuyluc? Danhmucgiacotthuyluc { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
    }
}