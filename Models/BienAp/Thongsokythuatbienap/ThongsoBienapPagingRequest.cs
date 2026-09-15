using WebApi.Models.Common;

namespace WebApi.Models.Bienap.Thongsokythuatbienap
{
    public class ThongsoBienapPagingRequest : PagingRequestBase
    {
        public int? thietbiId { get; set; }
    }
}