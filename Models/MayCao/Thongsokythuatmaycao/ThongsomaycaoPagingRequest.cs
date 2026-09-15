using WebApi.Models.Common;

namespace WebApi.Models.MayCao.ThongsokythuatMayCao
{
    public class ThongsomaycaoPagingRequest : PagedResultBase
    {
        public int? thietbiId { get; set; }
    }
}