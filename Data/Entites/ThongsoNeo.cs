using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ThongSoNeo")]
    public class ThongsoNeo
    {
        public int Id { get; set; }

        public int NeoId { get; set; }

        public string? NoiDung { get; set; } 

        public string? DonViTinh { get; set; } 

        public string? ThongSo { get; set; } 

        [ForeignKey("NeoId")]
        public virtual DanhmucNeo? DanhmucNeo { get; set; }
    }
}