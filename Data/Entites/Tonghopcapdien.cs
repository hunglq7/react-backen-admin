using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("Tonghopcapdien")]
    public class Tonghopcapdien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Maquanly { get; set; }
        public int DonviId { get; set; }
        public DateTime Ngaythang { get; set; }
        public int CapdienId { get; set; }
        public string? Donvitinh { get; set; }
        public int Tondauthang { get; set; }
        public int Nhaptrongky { get; set; }
        public int Xuattrongky { get; set; }
        public int Toncuoithang { get; set; }
        public int Dangsudung { get; set; }
        public int Duphong { get; set; }
        [MaxLength(500)]
        public string? Ghichu { get; set; }
        [ForeignKey("DonviId")]
        public virtual PhongBan? PhongBan { get; set; }
        [ForeignKey("CapdienId")]
        public virtual Capdien? Capdien { get; set; } 

    }
}
