
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("Camera")]
    public class Camera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string TenThietBI { get; set; } = string.Empty;
       
        [StringLength (5000)]
        public string ThongSoKyThuat { get; set; } = string.Empty;
        [StringLength (100)]
        public string NuocSanXuat { get; set; } = string.Empty;
        [StringLength(100)]
        public string HangSanXuat { get; set; } = string.Empty;
        [StringLength (50)]
        public string NamSanXuat { get; set; } = string.Empty;
        [StringLength (1000)]
        public string GhiChu { get; set; } = string.Empty;
    
        public virtual IEnumerable<TonghopCamera>? TonghopCameras { get; set; }

    }
}
