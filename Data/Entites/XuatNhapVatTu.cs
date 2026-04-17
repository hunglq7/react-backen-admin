using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Entites
{
    public class XuatNhapVatTu
    {
        public int Id { get; set; }

        public int ThietBiId { get; set; }
        public ThietBi ThietBi { get; set; }

        public DateTime Ngay { get; set; }
        public string Loai { get; set; } // NHAP / XUAT

        public decimal SoLuong { get; set; }

        public int? DonViId { get; set; }
        public PhongBan? DonVi { get; set; }

        public int? ViTriId { get; set; }
        public ViTri? ViTri { get; set; }

        public DateTime? NgayBatDauBaoHanh { get; set; }

        public string? GhiChu { get; set; }
    }
}