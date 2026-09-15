using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("ThongsokythuatMayxuc")]
    public class ThongsokythuatMayxuc
    {
        public int Id { get; set; }
        public int MayXucId { get; set; }
        public string? NoiDung { get; set; } 
        public string? DonViTinh { get; set; }
        public string? ThongSo { get; set; }

        public virtual MayXuc? MayXuc { get; set; }
    }
}
