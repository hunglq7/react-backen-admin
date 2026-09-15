namespace Api.Models.Danhmuctoitruc
{
    public class DanhmuctoitrucVm
    {
         public int Id { get; set; }  
        public string TenThietBi { get; set; } = string.Empty;       
        public string LoaiThietBi { get; set; } = string.Empty;
        public string NamSanXuat { get; set; } = string.Empty;   
        public string HangSanXuat { get; set; } = string.Empty;
        public Boolean TinhTrang{ get; set; }       
        public string GhiChu { get; set; } = string.Empty;
        
    }
}