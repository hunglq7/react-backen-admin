using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Chucvu;

namespace WebApi.Data.Entites
{
    [Table("NhanvienImage")]
    public class NhanvienImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NhanVienId { get; set; }

        public string? ImagePath { get; set; }
        [MaxLength(255)]
        public string? Caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }
        public int SortOrder { get; set; }

        public long FileSize { get; set; }

        [ForeignKey(nameof(NhanVienId))]
        public virtual NhanVien? NhanVien { get; set; }
    }
}
