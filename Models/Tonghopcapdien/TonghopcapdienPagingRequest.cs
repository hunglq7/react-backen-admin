using WebApi.Models.Common;

namespace WebApi.Models.Tonghopcapdien
{
    public class TonghopcapdienPagingRequest:PagingRequestBase
    {
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
    }
}
