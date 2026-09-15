using WebApi.Models.Common;

namespace Api.Models.Tonghopmayxuc
{
    public class QueryParametersPage : PagingRequestBase

    {
        public string? Keyword { get; set; }

    }
}