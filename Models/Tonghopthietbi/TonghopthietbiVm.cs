using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Tonghopthietbi
{
    public class TonghopthietbiVm
    {
        public int Id { get; set; }
       
        public string? MaThietBi { get; set; }
        public bool TrangThai { get; set; }
      
        public string? HinhAnh { get; set; }
        public string? TenThietBi { get; set; }
        public string? TenDonViTinh{ get; set; }
        public int SoLuong { get; set; }

        public string? TenLoai { get; set; }
        public DateTime NgaySuDung { get; set; }
        public string? TinhTrangThietBi { get; set; }
        public string? TenPhong { get; set; }
        public string? TenNhanvien { get; set; }
        public int TongMT { get; set; }
        public int TongMI { get; set; }
    }
}
