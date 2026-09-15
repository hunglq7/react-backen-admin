using WebApi.Models.Common;
namespace WebApi.Models.Neo.ThongsoNeo
{
    public class ThongsoNeoPagingRequest : PagedResultBase
    {
        public int? thietbiId { get; set; }
    }

}