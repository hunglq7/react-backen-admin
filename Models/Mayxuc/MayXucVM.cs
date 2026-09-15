using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Mayxuc
{
    public class MayXucVM
    {
        public int Id { get; set; }
        public string MaTaiSan { get; set; } = string.Empty;
        public string TenThietBi { get; set; } = string.Empty;
       
        public string LoaiThietBi { get; set; } = string.Empty;
        public string NamSanXuat { get; set; } = string.Empty;   
        public string HangSanXuat { get; set; } = string.Empty;
        public Boolean TinhTrang{ get; set; }       
        public string GhiChu { get; set; } = string.Empty;
    }
}
