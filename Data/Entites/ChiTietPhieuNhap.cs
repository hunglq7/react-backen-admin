using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.Entites
{
    [Table("ChiTietPhieuNhap")]
    [PrimaryKey(nameof(PhieuNhapId),nameof(VatTuId))]
    public class ChiTietPhieuNhap
    {
        
        [Column(Order = 1)]
        public int PhieuNhapId { get; set; }

        [ForeignKey("PhieuNhapId")]
        public virtual PhieuNhap? PhieuNhap { set; get; }
        public bool TrangThai {  get; set; }
        
        [Column(Order = 2)]
        public int VatTuId { get; set; }

        public int DonViTinhId { get; set; }

        [Required]
        public int SoLuongNhap { get; set; }

        [ForeignKey("VatTuId")]
        public virtual VatTu? VatTu { get; set; }

        [ForeignKey("DonViTinhId")]
        public virtual DonViTinh? DonViTinh { get; set; }
    }
}
