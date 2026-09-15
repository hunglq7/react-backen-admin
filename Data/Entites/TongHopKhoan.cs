using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entites
{
    [Table("TongHopKhoan")]
    public class TongHopKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int KhoanId { get; set; }

        [Required]
        public int DonViId { get; set; }

        [Required]
        [MaxLength(200)]
        public string? DonViTinh { get; set; } 

        [Required]
        public int SoLuong { get; set; }

        [Required]
        public DateTime NgayLap { get; set; }

        [MaxLength(500)]
        public string? ViTriLapDat { get; set; }

        [MaxLength(200)]
        public string? TinhTrangKyThuat { get; set; } 
        public Boolean duPhong { get; set; }

        [MaxLength(500)]
        public string GhiChu { get; set; } = string.Empty;

        // Navigation properties
        [ForeignKey("KhoanId")]
        public virtual DanhMucKhoan? DanhMucKhoan { get; set; }
        [ForeignKey("DonViId")]
        public virtual PhongBan? PhongBan { get; set; }
    }
}