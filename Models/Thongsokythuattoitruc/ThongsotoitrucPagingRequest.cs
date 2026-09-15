using WebApi.Models.Common;
namespace WebApi.Models.Thongsokythuattoitruc
{
    public class ThongsotoitrucPagingRequest:PagedResultBase
    {
        public int? thietbiId { get; set; }
    }
}
