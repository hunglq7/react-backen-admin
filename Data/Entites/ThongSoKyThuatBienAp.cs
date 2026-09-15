using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Entites
{
    [Table("ThongSoKyThuatBienAp")]
    public class ThongSoKyThuatBienAp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BienApId { get; set; }
        public string? NoiDung { get; set; }
        public string? DonViTinh { get; set; }
        public string? ThongSo { get; set; }
        [ForeignKey("BienApId")]
        public virtual DanhmucBienap? DanhmucBienap { get; set; }
    }
}