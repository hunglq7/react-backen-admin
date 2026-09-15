using WebApi.Models.Common;

namespace WebApi.Models.Tonghopthietbi
{
    public class TonghopthietbiPagingRequest : PagedResultBase
    {
        public int? nhanVienId { get; set; }
        public int? donviId { get; set; }
    }
}