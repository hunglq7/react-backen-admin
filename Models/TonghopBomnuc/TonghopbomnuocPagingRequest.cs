using WebApi.Models.Common;
namespace WebApi.Models.TonghopBomnuc
{
    public class TonghopbomnuocPagingRequest: PagedResultBase
    {
        public int? thietbiId { get; set; }
        public int? donviId { get; set; }
        public Boolean duPhong { get; set; }
    }
}
