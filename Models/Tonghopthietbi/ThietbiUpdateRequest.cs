namespace WebApi.Models.Tonghopthietbi
{
    public class ThietbiUpdateRequest
    {
        public int id {  get; set; }
        public string? maThietBi { get; set; }
        public bool trangThai { get; set; }
        public string? hinhAnh { get; set; }
        public string? tenThietBi { get; set; }
        public int donViTinhId { get; set; }
        public int soLuong { get; set; }
        public int loaiThietBiId { get; set; }
        public DateTime ngaySuDung { get; set; }
        public string? tinhTrangThietBi { get; set; }
        public int phongBanId { get; set; }
        public int nhanVienId { get; set; }
        public string? ghiChu { get; set; }
    }
}
