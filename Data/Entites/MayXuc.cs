using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Data.Entites
{
    [Table("MayXuc")]
    public class MayXuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? MaTaiSan { get; set; } 
        [Required]
        [MaxLength(100)]
        public string? TenThietBi { get; set; } 
        [Required]
        [MaxLength(200)]
        public string? LoaiThietBi { get; set; } 
        [MaxLength(12)]             
        
        public string? NamSanXuat { get; set; } 
        [MaxLength(200)]
        public string? HangSanXuat { get; set; }
        public bool TinhTrang { get; set; }
        public string? GhiChu { get; set; } 
      
        public virtual IEnumerable<TongHopMayXuc>? TongHopMayXucs { get; set; }
        public virtual IEnumerable<ThongsokythuatMayxuc>? ThongsokythuatMayxucs { get; set; }    
    }
}
