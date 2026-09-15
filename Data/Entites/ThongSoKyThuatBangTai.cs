using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApi.Data.Entites
{
    [Table("ThongSoKyThuatBangTai")]
    public class ThongSoKyThuatBangTai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BangTaiId { get; set; }
        public string? NoiDung { get; set; }
        public string? DonViTinh { get; set; }
        public string? ThongSo { get; set; }
        [ForeignKey("BangTaiId")]
        public virtual DanhMucBangTai? DanhMucBangTai { get; set; }

    }
}