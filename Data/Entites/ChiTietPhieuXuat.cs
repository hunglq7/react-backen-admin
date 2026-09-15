using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.Entites
{
    [Table("ChiTietPhieuXuat")]
    [PrimaryKey(nameof(PhieuXuatId), nameof(VatTuId))]
    public class ChiTietPhieuXuat
    {
        
        [Column(Order = 1)]
        public int PhieuXuatId { get; set; }

        [ForeignKey("PhieuXuatId")]
        public virtual PhieuXuat? PhieuXuat { get; set; }
        public bool TrangThai {  get; set; }
      
        [Column(Order = 2)]
        public int VatTuId { get; set; }

        [ForeignKey("VatTuId")]
        public virtual VatTu? VatTu { get; set; }

        public int DonViTinhId { get; set; }

        [ForeignKey("DonViTinhId")]
        public virtual DonViTinh? DonViTinh { get; set; }

        [Required]
        public int SoLuong { get; set; }
    }
}
