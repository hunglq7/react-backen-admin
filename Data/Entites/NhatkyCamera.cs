using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("NhatkyCamera")]
    public class NhatkyCamera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CameraId { get; set; }
        public DateTime NgayThang { get; set; }
        public string? TinhTrang { get; set; }
        public int DonViQuanLyId { get; set; }
        public string? ViTriSuDung { get; set; } 
        public Boolean TrangThai { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("CameraId")]
        public virtual TonghopCamera? TonghopCamera { get; set; }
        [ForeignKey("DonViQuanLyId")]
        public virtual PhongBan? PhongBan { get; set; }
    }
}
