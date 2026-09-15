using WebApi.Models.Common;
namespace WebApi.Models.Tonghopquatgio
{
    public class TonghopquatgioPagingRequest:PagedResultBase
    {
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
    }
}
