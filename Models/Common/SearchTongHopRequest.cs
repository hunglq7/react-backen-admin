namespace WebApi.Models.Common
{
    public class SearchTongHopRequest:PagingRequestBase
    {
        public string? Keyword { get; set; }        // tìm theo chuỗi
        public bool? DuPhong { get; set; }        // true / false
        public DateTime? TuNgay { get; set; }       // từ ngày
        public DateTime? DenNgay { get; set; }      // đến ngày
    }
}
