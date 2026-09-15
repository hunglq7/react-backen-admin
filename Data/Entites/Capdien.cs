using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("Capdien")]
    public class Capdien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(500)]
        public string? Tenthietbi { get; set; }
        [MaxLength(500)]
        public string? Ghichu { get; set; }
        public virtual IEnumerable<Tonghopcapdien>? Tonghopcapdiens { get; set; }
    }
}
