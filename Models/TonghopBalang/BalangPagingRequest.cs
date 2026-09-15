using WebApi.Models.Common;

namespace WebApi.Models.TonghopBalang
{
    public class BalangPagingRequest: PagingRequestBase
    {
        public string? Keyword { get; set; }
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
    }
}
