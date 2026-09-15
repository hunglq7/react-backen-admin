using WebApi.Models.Common;

namespace WebApi.Models.MayCao.Tonghopmaycao
{
    public class TonghopmaycaoPagingRequest : PagedResultBase
    {
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
    }
}