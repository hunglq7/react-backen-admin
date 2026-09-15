using WebApi.Models.Common;

namespace WebApi.Models.Neo.TongHopNeo
{
    public class TongHopNeoPagingRequest : PagedResultBase
    {
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
    }
}