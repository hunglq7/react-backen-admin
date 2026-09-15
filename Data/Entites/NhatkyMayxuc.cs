using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("NhatkyMayxuc")]
    public class NhatkyMayxuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TonghopmayxucId { get; set; }
        [MaxLength(12)]
        public string? Ngaythang { get; set; }
        [Required]
        [MaxLength(50)]
        public string? DonVi { get; set; }
        [MaxLength(500)]
        public string? ViTri { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        [ForeignKey("TonghopmayxucId")]
        public virtual TongHopMayXuc? TongHopMayXuc { get; set; }

    }
}
