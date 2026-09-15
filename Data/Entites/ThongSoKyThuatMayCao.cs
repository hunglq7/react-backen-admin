using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ThongSoKyThuatMayCao")]
    public class ThongSoKyThuatMayCao
    {
        public int Id { get; set; }

        public int MayCaoId { get; set; }

        public string? NoiDung { get; set; } 

        public string? DonViTinh { get; set; } 

        public string? ThongSo { get; set; } 
        [ForeignKey("MayCaoId")]
        public virtual DanhmucMayCao? DanhmucMayCao { get; set; }
    }
}