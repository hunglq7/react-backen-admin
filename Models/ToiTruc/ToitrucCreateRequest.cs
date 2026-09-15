namespace WebApi.Models.ToiTruc
{
    public class ToitrucCreateRequest
    {
        public int Id { get; set; }
        public string MaQuanLy { get; set; } = string.Empty;
        public string MaHieu { get; set; } = string.Empty;
        public string TenLoai { get; set; } = string.Empty;
        public string NuocSX { get; set; } = string.Empty;
        public string HangSX { get; set; } = string.Empty;
        public string NamSX { get; set; } = string.Empty;
        public string CongSuat { get; set; } = string.Empty;
        public string DienAp { get; set; } = string.Empty;
        public string SoVongQuay { get; set; } = string.Empty;
        public string LucKeo { get; set; } = string.Empty;
        public string? TocDoKeoCham { get; set; }
        public string? TocDoKeoNhanh { get; set; }
        public string? TrongLuongToi { get; set; }
        public string? KichThuocNgoaiHinh { get; set; }
        public string? DuongKinhCap { get; set; }
        public string? ChieuDaiCapQuan { get; set; }
        public string? ApLucKhiNen { get; set; }
        public string? LuongKhiNenTieuHao { get; set; }
        public string? GiChu { get; set; }
    }
}
