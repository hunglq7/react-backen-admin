using WebApi.Models.Common;

namespace Api.Models.Tonghopmayxuc
{
    public class QueryParameters : PagingRequestBase

    {
        public string? Keyword { get; set; }        
    }
}