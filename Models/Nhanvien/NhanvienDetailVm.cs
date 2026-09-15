namespace WebApi.Models.Nhanvien
{
    public class NhanvienDetailVm
    {
        public int Id { get; set; }
        public string? SoThe { get; set; }
        public string? TenNhanVien { get; set; }
        public string? DienThoai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public string? HinhAnh { get; set; }
        public int PhongBanId {  get; set; }
        public int ChucVuId {  get; set; }
        public string? TenPhong { get; set; }
        public string? TenChucVu { get; set; }
        public string? GiChu { get; set; }
        public bool TrangThai { get; set; }
    }
}
