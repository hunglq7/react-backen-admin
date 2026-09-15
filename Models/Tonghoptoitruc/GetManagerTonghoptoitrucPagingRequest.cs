using WebApi.Models.Common;

namespace WebApi.Models.Tonghoptoitruc
{
    public class GetManagerTonghoptoitrucPagingRequest:PagingRequestBase
    {
        public string? Keyword { get; set; }
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
        public bool ? duPhong { get; set; }
    }
}
