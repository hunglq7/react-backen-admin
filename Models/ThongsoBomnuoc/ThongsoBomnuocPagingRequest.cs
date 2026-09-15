using WebApi.Models.Common;

namespace WebApi.Models.ThongsoBomnuoc
{
    public class ThongsoBomnuocPagingRequest:PagingRequestBase
    {
        public int? thietbiId { get; set; }
    }
}
