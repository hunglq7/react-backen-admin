using WebApi.Models.Common;

namespace WebApi.Models.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
