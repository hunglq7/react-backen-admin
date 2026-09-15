using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Data.Entites
{
    [Table("CapNhatGiaCot")]
    public class CapNhatGiaCot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CapNhatId { get; set; }
        public int DonViId { get; set; }
        public int LoaiThietBiId { get; set; }
        public int SoLuongDangQuanLy { get; set; }
        public string? ViTriSuDung { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey(nameof(DonViId))]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey(nameof(LoaiThietBiId))]
        public virtual DanhmucGiaCot? DanhmucGiaCot { get; set; }
    }
}
