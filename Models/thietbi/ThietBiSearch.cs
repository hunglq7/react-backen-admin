using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Common;

namespace WebApi.Models.thietbi
{
    public class ThietBiSearch : PagingRequestBase
    {
        public string? TenThietBi { get; set; }
        public string? Loai { get; set; }
        public string? HangSanXuat { get; set; }
    }
}