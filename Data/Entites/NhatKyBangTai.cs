using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi.Data.Entites
{
    [Table("NhatKyBangTai")]
    public class NhatKyBangTai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TongHopBangTaiId { get; set; }
        public string? Ngaythang { get; set; }
        [MaxLength(100)]
        public string? DonVi { get; set; }
        [MaxLength(500)]
        public string? ViTri { get; set; }
        [MaxLength(500)]
        public string? TrangThai { get; set; }
        [MaxLength(500)]
        public string? GhiChu { get; set; } 
        [ForeignKey("TongHopBangTaiId")]
        public virtual TongHopBangTai? TongHopBangTai { get; set; }
    }
}