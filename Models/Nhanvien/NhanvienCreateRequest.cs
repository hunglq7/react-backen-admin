namespace WebApi.Models.Nhanvien
{
    public class NhanvienCreateRequest
    {
        public int id { get; set; }
        public string? soThe { get; set; }
        public string? tenNhanVien { get; set; }
        public string? dienThoai { get; set; }
        public DateTime ngaySinh { get; set; }
        public string? diaChi { get; set; }
        public string? hinhAnh { get; set; }
        public int phongBanId { get; set; }
        public int chucVuId { get; set; }
        public string? ghiChu { get; set; }
        public bool trangThai { get; set; }
    }
}
