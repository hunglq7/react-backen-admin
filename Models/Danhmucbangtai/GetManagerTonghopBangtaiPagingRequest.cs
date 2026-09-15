using WebApi.Models.Common;

namespace WebApi.Models.Danhmucbangtai
{
    public class GetManagerTonghopBangtaiPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        public int? BangTaiId { get; set; }
        public int? DonViId { get; set; }
    }
}