namespace WebApi.Models.Danhmuckhoan
{
    public class DanhMucKhoanVm
    {
        public int Id { get; set; }
        public string TenThietBi { get; set; } = string.Empty;
        public string LoaiThietBi { get; set; } = string.Empty;
        public string GhiChu { get; set; } = string.Empty;
    }
}