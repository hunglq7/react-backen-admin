using WebApi.Models.Common;

namespace WebApi.Models.AptomatKhoidongtu.TonghopAptomatKhoidongtu
{
    public class TonghopaptomatkhoidongduPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
        public bool? duPhong { get; set; }
    }
}