using WebApi.Models.Common;

namespace Api.Models.AptomatKhoidongtu.ThongsoAptomatKhoidongtu
{
    public class ThongsoAptomatKhoidongtuPagingRequest : PagedResultBase
    {
        public int? thietbiId { get; set; }
    }
}