using WebApi.Models.Common;

namespace WebApi.Models.TonghopKhoan
{
    public class KhoanPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        public int? ThietBiId { get; set; }
        public int? DonViId { get; set; }
    }
}