namespace WebApi.Models.ToiTruc
{
    public class ToitrucVm
    {
        public int Id { get; set; }
        public string MaQuanLy { get; set; } = string.Empty;
        public string MaHieu { get; set; } = string.Empty;
        public string TenLoai { get; set; } = string.Empty;
        public string NuocSX { get; set; } = string.Empty;
        public string HangSX { get; set; } = string.Empty;
        public string NamSX { get; set; } = string.Empty;
    }
}
