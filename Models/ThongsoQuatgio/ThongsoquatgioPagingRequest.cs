using WebApi.Models.Common;
namespace WebApi.Models.ThongsoQuatgio
{
    public class ThongsoquatgioPagingRequest:PagingRequestBase
    {
        public int? thietbiId { get; set; }
    }
}
